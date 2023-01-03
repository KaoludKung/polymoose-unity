using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private Button audioButton;
    [SerializeField] private List<Button> options;

    [SerializeField] private AudioSource correctClip;
    [SerializeField] private AudioSource wrongClip;

    private Question question;
    private bool answered;
    private float audioLength;

    
    void Awake()
    {
        for(int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClicK(localButton));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                audioButton.transform.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImage;
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                audioButton.transform.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                audioButton.onClick.AddListener(AudioPlay);
                break;
        }

        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for(int i = 0; i <options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = Color.white;
        }
        answered = false;  
    }

    void AudioPlay()
    {
        if (question.questionType == QuestionType.AUDIO)
        {
           questionAudio.clip = question.questionClip;
           questionAudio.Play();
        }
    }

    ///?????????///
    IEnumerator PlayAudio()
    {
        if(question.questionType == QuestionType.AUDIO)
        {
            questionAudio.PlayOneShot(question.questionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);
            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        audioButton.transform.gameObject.SetActive(false);
    }

    private void OnClicK(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = Color.green;
                correctClip.Play();
                Debug.Log("Corret!");
            }
            else
            {
                btn.image.color = Color.red;
                wrongClip.Play();
                Debug.Log("Wrong!");
            }
        }   
        
    }
}

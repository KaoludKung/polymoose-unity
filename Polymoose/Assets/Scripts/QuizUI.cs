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
    [SerializeField] private bool fillBlank;

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

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                //questionText.transform.parent.gameObject.SetActive(true);
                questionImage.transform.parent.gameObject.SetActive(false);
                audioButton.transform.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                //questionText.transform.parent.gameObject.SetActive(false);
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

        if (quizManager.fillBlank)
        {
            questionText.text = "<color=#3BF831>Fill the blank: </color>" + question.questionInfo;
        }
        else
        {
            questionText.text = "<color=#3BF831>Question: </color>" + question.questionInfo;
        }

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for(int i = 0; i <options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = new Color32(0,0,0,180);
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
        if (!answered && !quizManager.timeOver)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = new Color32(70,202,78,255);
                correctClip.Play();
                Debug.Log("Corret!");
            }
            else
            {
                btn.image.color = new Color32(255,51,51,255);
                wrongClip.Play();
                Debug.Log("Wrong!");
            }
        }   
        
    }
}

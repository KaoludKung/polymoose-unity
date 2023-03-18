using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TestUI : MonoBehaviour
{

    [SerializeField] private TestManager testManager;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options;

    [SerializeField] private AudioSource correctClip;
    [SerializeField] private AudioSource wrongClip;

    private QuestionTest question;
    private bool answered;
    private float audioLength;


    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localButton = options[i];
            localButton.onClick.AddListener(() => OnClicK(localButton));
        }
    }

    public void SetQuestion(QuestionTest question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                //questionText.transform.parent.gameObject.SetActive(true);
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                //questionText.transform.parent.gameObject.SetActive(false);
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImage;
                break;
        }

        if (testManager.fillBlanks)
        {
            questionText.text = "<color=#3BF831>Fill in the blank: </color>" + question.questionInfo;
        }
        else
        {
            questionText.text = "<color=#3BF831>Question: </color>" + question.questionInfo;
        }

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = Color.white;
        }
        answered = false;
    }

  

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
    }

    private void OnClicK(Button btn)
    {
        if (!answered)
        {
            answered = true;
            bool val = testManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = new Color32(70, 202, 78, 255);
                correctClip.Play();
                Debug.Log("Corret!");
            }
            else
            {
                btn.image.color = new Color32(255, 51, 51, 255);
                wrongClip.Play();
                Debug.Log("Wrong!");
            }
        }

    }
}

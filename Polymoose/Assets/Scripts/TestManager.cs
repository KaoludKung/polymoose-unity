using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TestManager : MonoBehaviour
{
    [SerializeField] private TestUI testUI;
    [SerializeField] private List<QuestionTest> questions;
    [SerializeField] private QuestionTest selectedQuestion;

    [SerializeField] private int level;
    [SerializeField] private int questionNum;
    [SerializeField] private bool firstQuestion;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameObject currentObject;
    public GameObject nextObject;
    public bool fillBlanks;

    private int index = 0;
    private int score;
    //private int count;


    private void Awake()
    {
        if (firstQuestion)
        {
            PlayerPrefs.SetInt("Score" + level, 0);
            PlayerPrefs.SetInt("Count" + level, 0);
            PlayerPrefs.SetInt("Totalcorrect" + level, 1);
        }

        score = PlayerPrefs.GetInt("Score" + level, score);
        //count = PlayerPrefs.GetInt("Count" + level, count);

        scoreText.text = "Score: " + score.ToString() + "/10";
        //processbar.fillAmount = (count++) / 10f;

    }

    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();

        //Debug.Log(count);
        Debug.Log(score);
 
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    void SelectQuestion()
    {
        if (index < questionNum)
        {
            int val = Random.Range(0, questions.Count);
            selectedQuestion = questions[val];
            testUI.SetQuestion(selectedQuestion);
            index++;
            questions.RemoveAt(val);
        }
        else
        {
            Invoke("EndQuiz", 1.5f);
        }
    }

    void EndQuiz()
    {
        Destroy(currentObject);
        nextObject.SetActive(true);
        Debug.Log("Next Object");
    }

    public bool Answer(string answered)
    {
        bool correctAnswer = false;

        if (answered == selectedQuestion.correctAnswer)
        {
            correctAnswer = true;
            score += 1;
            scoreText.text = "Score: " + score.ToString() + "/10";
        }

        PlayerPrefs.SetInt("Score" + level, score);
        //PlayerPrefs.SetInt("Count" + level, count++);
        Invoke("SelectQuestion", 3.0f);
        return correctAnswer;
    }
}

[System.Serializable]
public class QuestionTest
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImage;
    public List<string> options;
    public string correctAnswer;
}

[System.Serializable]
public enum TestType
{
    TEXT,
    IMAGE
}

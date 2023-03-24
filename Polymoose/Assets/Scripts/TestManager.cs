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
    [SerializeField] private TextMeshProUGUI countText;
    public GameObject[] panelResult;
    public GameObject currentObject;
    public GameObject nextObject;
    public bool respone;
    public bool blanks;

    private int index = 0;
    private int score;
    private int count;


    private void Awake()
    {

        if (firstQuestion)
        {
            PlayerPrefs.SetInt("Score" + level, 0);
            PlayerPrefs.SetInt("Count" + level, 0);
            PlayerPrefs.SetInt("Count" + level, 1);
        }

        score = PlayerPrefs.GetInt("Score" + level, score);
        count = PlayerPrefs.GetInt("Count" + level, count);

        scoreText.text = "Score: " + score.ToString();
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
            panelResult[0].SetActive(false);
            panelResult[1].SetActive(false);
            countText.text = "Question " + count + " of " + "10";
            int val = Random.Range(0, questions.Count);
            selectedQuestion = questions[val];
            testUI.SetQuestion(selectedQuestion);
            index++;
            questions.RemoveAt(val);
        }
        else
        {
            Invoke("EndQuiz", 2.5f);
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
            scoreText.text = "Score: " + score.ToString();
        }

        PlayerPrefs.SetInt("Count" + level, count++);
        PlayerPrefs.SetInt("Score" + level, score);
        Invoke("SelectQuestion", 4.0f);
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

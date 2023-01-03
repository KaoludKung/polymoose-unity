using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private SummaryManager summaryManager;
    [SerializeField] private List<Question> questions;
    [SerializeField] private Question selectedQuestion;
    [SerializeField] private int questionNum;

    [SerializeField] private GameObject hints;
    [SerializeField] private Button hintsButton;
    [SerializeField] private Button freezeButton;
    [SerializeField] private Button extraButton;

    [SerializeField] private Transform fillBar;
    [SerializeField] private float delay;
    [SerializeField] private float timeBouns;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI hintCountText;
    [SerializeField] private TextMeshProUGUI freezeCountText;
    [SerializeField] private TextMeshProUGUI extraCountText;

    private int hintCount;
    private int freezeCount;
    private int extraCount;

    private float currentTime;
    private int index = 0;
    
    private int gameScore;
    private int corretStack = 0;
    private int resultStack = 0;
    private int coinStack = 1;
    
    private bool isRunning = false;
    private bool isUsing = false;

    public int level;
    private int coinCount;
    private int totalCoin;
    private int stars;
    private int currentStars;
    
    private int highScore;
    private int percent;
    private float result;

    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
        hints.GetComponent<TextMeshProUGUI>().text = selectedQuestion.correctAnswer;

        hintCount = PlayerPrefs.GetInt("Hints", hintCount);
        freezeCount = PlayerPrefs.GetInt("Freezes", freezeCount);
        extraCount = PlayerPrefs.GetInt("Extratimes", extraCount);

        hintCountText.text = hintCount.ToString();
        freezeCountText.text = freezeCount.ToString();
        extraCountText.text = extraCount.ToString();

        hintsButton.onClick.AddListener(ShowHints);
        freezeButton.onClick.AddListener(StopTime);
        extraButton.onClick.AddListener(ExtraTime);

        highScore = PlayerPrefs.GetInt("Highscore" + level, highScore);
        stars = PlayerPrefs.GetInt("Stars" + level, stars);
        coinCount = PlayerPrefs.GetInt("Coins", coinCount);
        totalCoin = PlayerPrefs.GetInt("Totalcoin", totalCoin);
    }

    // Update is called once per frame
    void Update()
    {
        hintCountText.text = hintCount.ToString();
        freezeCountText.text = freezeCount.ToString();
        extraCountText.text = extraCount.ToString();

        if (isRunning)
        {
            currentTime -= delay * Time.deltaTime;
            fillBar.GetComponent<Image>().fillAmount = currentTime;
            hints.GetComponent<TextMeshProUGUI>().text = selectedQuestion.correctAnswer;

            if (currentTime < 0)
            {
                isRunning = false;
                Invoke("SelectQuestion", 1.0f);
            }
        }
    }

    void SelectQuestion()
    {
        if(index < questionNum)
        {
            currentTime = 1;
            int val = UnityEngine.Random.Range(0, questions.Count);
            selectedQuestion = questions[val];
            quizUI.SetQuestion(selectedQuestion);
            isRunning = true;
            questions.RemoveAt(val);
            index += 1;
        }
        else
        {
            EndGame();
        }
    }

    public bool Answer(string answered)
    {
        bool correctAnswer = false;
        
        if(answered == selectedQuestion.correctAnswer)
        {
            correctAnswer = true;
            corretStack++;
            resultStack++;
            coinStack++;
            gameScore += 500;
            
            if(corretStack > 0)
            {
                gameScore += 50 * corretStack;
            }

            scoreText.text = "Score : " + gameScore;
        }
        else
        {
            corretStack = 0;
        }

        isRunning = false;
        Invoke("SelectQuestion", 2.5f);
        return correctAnswer;
    }

    void ShowHints()
    {
        StartCoroutine(Hints());
    }

    void StopTime()
    {
        StartCoroutine(TimeStop());
    }

    void ExtraTime()
    {
        StartCoroutine(AddTime());
    }

    IEnumerator Hints()
    {
        if(hintCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                yield return new WaitForSeconds(1f);
                hints.SetActive(true);

                hintCount--;
                PlayerPrefs.SetInt("Hints", hintCount);
                PlayerPrefs.Save();

                yield return new WaitForSeconds(5f);
                hints.SetActive(false);
                isUsing = false;
            }
        }
        else
        {
            Debug.Log("Can't use item!");
        }
        
    }

    IEnumerator TimeStop()
    {
        if(freezeCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                yield return new WaitForSeconds(1.0f);
                isRunning = false;

                freezeCount--;
                PlayerPrefs.SetInt("Freezes", freezeCount);
                PlayerPrefs.Save();

                yield return new WaitForSeconds(10.0f);
                isRunning = true;
                isUsing = false;
            }
        }
        else
        {
            Debug.Log("Can't use item!");
        }
    }

    IEnumerator AddTime()
    {
        if(extraCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                yield return new WaitForSeconds(1.0f);
                currentTime += timeBouns;

                extraCount--;
                PlayerPrefs.SetInt("Extratimes", extraCount);
                PlayerPrefs.Save();

                if (currentTime > 1)
                {
                    currentTime = 1;
                }

                isUsing = false;
            }
        }
        else
        {
            Debug.Log("Can't use item!");
        }
    }

    void EndGame()
    {
        CalculateScore();
        UpdateData();
        
        if (percent >= 30)
        {
            summaryManager.summaryText.text = "LEVEL CLEAR!";

            if (PlayerPrefs.GetInt("Level") == 0)
            {
                PlayerPrefs.SetInt("Level", 1);
            }

            if (level >= PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", level + 1);
            }

            PlayerPrefs.SetInt("Firstclear", 1);
            PlayerPrefs.Save();

            OpenCanvas();   
        }
        else
        {
            summaryManager.summaryText.text = "LEVEL FAILED!";
            OpenCanvas();
        }

        Debug.Log("End");
    }

    void OpenCanvas()
    {
        int coinResult = 10 * coinStack;

        summaryManager.finalScoreText.text = gameScore.ToString();
        summaryManager.coinText.text = coinResult.ToString();
        ChangeStar();

        summaryManager.currentCanvas.SetActive(false);
        summaryManager.summaryCanvas.SetActive(true);
    }

    void ChangeStar()
    {
        if(currentStars == 1)
        {
            summaryManager.star2.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            summaryManager.star3.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            Debug.Log("1 Star");
        }
        else if(currentStars == 2)
        {
            summaryManager.star3.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            Debug.Log("2 Star");
        }
        else if(currentStars == 3)
        {
            Debug.Log("3 Star");
        }
        else
        {
            summaryManager.star1.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            summaryManager.star2.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            summaryManager.star3.GetComponent<Image>().color = new Color32(192, 192, 192, 100);
            Debug.Log("No Star");
        }
    }

    void CalculateScore()
    {
        result = (gameScore/3250f) * 100f;
        percent = (int)Math.Round(result);

        if(percent >= 80)
        {
            currentStars = 3;
        }
        else if(percent >= 60)
        {
            currentStars = 2;
        }
        else if(percent >= 30)
        {
           currentStars = 1;
        }
    }

    void UpdateData()
    {
        PlayerPrefs.SetInt("Coins", coinCount + (10 * coinStack));
        PlayerPrefs.SetInt("Totalcoin", totalCoin + (10 * coinStack));
        PlayerPrefs.Save();

        if (gameScore > PlayerPrefs.GetInt("Highscore" + level))
        {
            highScore = gameScore;
            PlayerPrefs.SetInt("Highscore" + level, highScore);
            PlayerPrefs.Save();
        }

        if(currentStars > PlayerPrefs.GetInt("Stars" + level))
        {
            stars = currentStars;
            PlayerPrefs.SetInt("Stars" + level, stars);
            PlayerPrefs.Save();
        }

        if(resultStack == questionNum)
        {
            PlayerPrefs.SetInt("Fullstack", 1);
            PlayerPrefs.Save();
        }
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionImage;
    public AudioClip questionClip;
    public Button audioButton;
    public List<string> options;
    public string correctAnswer;
}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    AUDIO
}
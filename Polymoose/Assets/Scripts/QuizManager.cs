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
    [SerializeField] private List<Question> questions;
    [SerializeField] private Question selectedQuestion;

    [SerializeField] private int level;
    [SerializeField] private int questionNum;
    [SerializeField] private bool firstQuestion;
 
    [SerializeField] private GameObject hintsText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image processbar;

    [SerializeField] private TextMeshProUGUI hintCountText;
    [SerializeField] private TextMeshProUGUI freezeCountText;
    [SerializeField] private TextMeshProUGUI extraCountText;

    [SerializeField] private Button hintsButton;
    [SerializeField] private Button freezeButton;
    [SerializeField] private Button extraButton;

    [SerializeField] private GameObject[] items;
    [SerializeField] private AudioSource itemSource;
    [SerializeField] private AudioClip[] itemClip;

    private float currentTime;
    private int index = 0;
    private int score;
    private int combo;
    private int count;
    private int totalCorrect;

    private int hintCount;
    private int freezeCount;
    private int extraCount;

    private bool isRunning = false;
    private bool isUsing = false;
    public bool timeOver = true;

    public GameObject currentObject;
    public GameObject nextObject;

    private void Awake()
    {
        if (firstQuestion)
        {
            PlayerPrefs.SetInt("Score" + level, 0);
            PlayerPrefs.SetInt("Combo" + level, 0);
            PlayerPrefs.SetInt("Count" + level, 0);
            PlayerPrefs.SetInt("Totalcorrect" + level, 1);
        }
        
        combo = PlayerPrefs.GetInt("Combo" + level, combo);
        score = PlayerPrefs.GetInt("Score" + level, score);
        count = PlayerPrefs.GetInt("Count" + level, count);
        totalCorrect = PlayerPrefs.GetInt("Totalcorrect" + level, totalCorrect);
        
        scoreText.text = "Score : " + score.ToString();
        processbar.fillAmount = (count++) / 5f;

        hintCount = PlayerPrefs.GetInt("Hints", hintCount);
        freezeCount = PlayerPrefs.GetInt("Freezes", freezeCount);
        extraCount = PlayerPrefs.GetInt("Extratimes", extraCount);

        hintsText.GetComponent<TextMeshProUGUI>().text = selectedQuestion.correctAnswer;
        hintCountText.text = hintCount.ToString();
        freezeCountText.text = freezeCount.ToString();
        extraCountText.text = extraCount.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();

        Debug.Log(count);
        Debug.Log(score);
        Debug.Log(combo);

        hintsButton.onClick.AddListener(() => UseItem(1));
        freezeButton.onClick.AddListener(() => UseItem(2));
        extraButton.onClick.AddListener(() => UseItem(3));
    }

    // Update is called once per frame
    void Update()
    {
        hintCountText.text = hintCount.ToString();
        freezeCountText.text = freezeCount.ToString();
        extraCountText.text = extraCount.ToString();
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            processbar.fillAmount = count / 5f;
            hintsText.GetComponent<TextMeshProUGUI>().text = selectedQuestion.correctAnswer;

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timerText.text = currentTime.ToString("###0");
            }
            else
            {
                isRunning = false;
                timeOver = true;
                itemSource.clip = itemClip[4];
                itemSource.Play();
                PlayerPrefs.SetInt("Count" + level, count++);
                Invoke("SelectQuestion", 3.0f);
            }
        }
    }

    void SelectQuestion()
    {
        if(index < questionNum)
        {
            int val = UnityEngine.Random.Range(0, questions.Count);
            currentTime = 15.0f;
            timeOver = false;
            selectedQuestion = questions[val];
            quizUI.SetQuestion(selectedQuestion);

            for (int i = 0; i < items.Length; i++)
            {
                items[i].SetActive(true);
            }

            isRunning = true;
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

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }

        nextObject.SetActive(true);
        Debug.Log("Next Object");
    }

    public bool Answer(string answered)
    {
        bool correctAnswer = false;
        
        if(answered == selectedQuestion.correctAnswer)
        {
            correctAnswer = true;
            score += 500;
            combo++;
            totalCorrect++;
            
            if(combo > 0)
            {
                score += 50 * combo;
            }

            scoreText.text = "Score : " + score;
        }
        else
        {
            combo = 0;
        }

        isRunning = false;
        PlayerPrefs.SetInt("Score" + level, score);
        PlayerPrefs.SetInt("Combo" + level, combo);
        PlayerPrefs.SetInt("Count" + level, count++);
        PlayerPrefs.SetInt("Totalcorrect" + level, totalCorrect);
        Invoke("SelectQuestion", 3.0f);
        return correctAnswer;
    }

    private void UseItem(int id)
    {
        switch (id)
        {
            case 1:
                StartCoroutine(Hints());
                break;
            
            case 2:
                StartCoroutine(TimeStop());
                break;
            
            case 3:
                StartCoroutine(AddTime());
                break;
        }
        
    }

    IEnumerator Hints()
    {
        if (hintCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                itemSource.clip = itemClip[1];
                itemSource.Play();
                yield return new WaitForSeconds(0.5f);
                hintsText.SetActive(true);

                hintCount--;
                PlayerPrefs.SetInt("Hints", hintCount);
                PlayerPrefs.Save();

                yield return new WaitForSeconds(2.5f);
                hintsText.SetActive(false);
                isUsing = false;
            }
        }
        else
        {
            itemSource.clip = itemClip[0];
            itemSource.Play();
            Debug.Log("Can't use item!");
        }

    }

    IEnumerator TimeStop()
    {
        if (freezeCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                itemSource.clip = itemClip[2];
                itemSource.Play();
                yield return new WaitForSeconds(0.5f);
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
            itemSource.clip = itemClip[0];
            itemSource.Play();
            Debug.Log("Can't use item!");
        }
    }

    IEnumerator AddTime()
    {
        if (extraCount > 0 && isRunning)
        {
            if (!isUsing)
            {
                isUsing = true;
                itemSource.clip = itemClip[3];
                itemSource.Play();
                yield return new WaitForSeconds(0.5f);
                currentTime += 5;

                extraCount--;
                PlayerPrefs.SetInt("Extratimes", extraCount);
                PlayerPrefs.Save();

                isUsing = false;
            }
        }
        else
        {
            itemSource.clip = itemClip[0];
            itemSource.Play();
            Debug.Log("Can't use item!");
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
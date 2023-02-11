using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SummaryManager : MonoBehaviour
{
    [SerializeField] GameObject[] starImage;
    [SerializeField] GameObject summaryCanvas;
    [SerializeField] GameObject highscoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI summaryText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] private AudioSource levelSource;
    [SerializeField] private AudioClip[] levelClip;
  
    public int level;
    public int quizCount;
    public float maxScore;
    
    private int percent;
    private int highScore;
    private int score;
    private int combo;
    private int totalCorrect;
    
    private int coinCount;
    private int totalCoin;
    private int stars;
    private int currentStars;
    private bool isHighscore = false;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score" + level, score);
        combo = PlayerPrefs.GetInt("Combo" + level, combo);
        totalCorrect = PlayerPrefs.GetInt("Totalcorrect" + level, totalCorrect);
        coinCount = PlayerPrefs.GetInt("Coins", coinCount);
        totalCoin = PlayerPrefs.GetInt("Totalcoin", totalCoin);

        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        CalculateScore();
        UpdateData();

        if (percent >= 30)
        {
            summaryText.text = "LEVEL CLEAR!";

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
            yield return new WaitForSeconds(0.8f);
            levelSource.clip = levelClip[0];
            levelSource.Play();
        }
        else
        {
            summaryText.text = "LEVEL FAILED!";
            OpenCanvas();
            yield return new WaitForSeconds(0.8f);
            levelSource.clip = levelClip[1];
            levelSource.Play();
        }

        Debug.Log("End");
    }

    void OpenCanvas()
    {
        scoreText.text = score.ToString();
        coinText.text = (20 * totalCorrect).ToString();
        ChangeStar();
        summaryCanvas.SetActive(true);

        if (isHighscore)
        {
            highscoreText.SetActive(true);
            isHighscore = false;
        }
    }

    void ChangeStar()
    {
        if (currentStars == 1)
        {
            starImage[1].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            starImage[2].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            Debug.Log("1 Star");
        }
        else if (currentStars == 2)
        {
            starImage[2].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            Debug.Log("2 Star");
        }
        else if (currentStars == 3)
        {
            Debug.Log("3 Star");
        }
        else
        {
            for(int i = 0; i < starImage.Length; i++)
            {
                starImage[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            }
            Debug.Log("Failed");
        }
    }

    void CalculateScore()
    {
        percent = (int)Math.Round((score / maxScore) * 100f);
        Debug.Log("Percent: " + percent);

        if (percent >= 85)
        {
            currentStars = 3;
        }
        else if (percent >= 55)
        {
            currentStars = 2;
        }
        else if (percent >= 25)
        {
            currentStars = 1;
        }
    }

    void UpdateData()
    {
        PlayerPrefs.SetInt("Coins", coinCount + (20 * totalCorrect));
        PlayerPrefs.SetInt("Totalcoin", totalCoin + (20 * totalCorrect));
       
        if (score > PlayerPrefs.GetInt("Highscore" + level))
        {
            highScore = score;
            isHighscore = true;
            PlayerPrefs.SetInt("Highscore" + level, highScore);
        }

        if (currentStars > PlayerPrefs.GetInt("Stars" + level))
        {
            stars = currentStars;
            PlayerPrefs.SetInt("Stars" + level, stars);
        }

        if (combo == quizCount)
        {
            PlayerPrefs.SetInt("Fullstack", 1);
        }
    }
}

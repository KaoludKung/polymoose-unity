using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TestSummary : MonoBehaviour
{
    [SerializeField] GameObject starImage;
    [SerializeField] GameObject summaryCanvas;
    [SerializeField] GameObject highscoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI summaryText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] private AudioSource levelSource;
    [SerializeField] private AudioClip[] levelClip;
    public bool postTest;

    public int level;
    public int quizCount;
    public float maxScore;

    private int percent;
    private int highScore;
    private int score;
  
    private int coinCount;
    private int totalCoin;
    private int stars;
    private int currentStars;
    private bool isHighscore = false;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score" + level, score);
        coinCount = PlayerPrefs.GetInt("Coins", coinCount);
        totalCoin = PlayerPrefs.GetInt("Totalcoin", totalCoin);

        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        CalculateScore();
        UpdateData();

        if (percent >= 70 && postTest)
        {
            summaryText.text = "LEVEL CLEARED!";

            if (level >= PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", level + 1);
            }

            OpenCanvas();
            yield return new WaitForSeconds(0.8f);
            levelSource.clip = levelClip[0];
            levelSource.Play();
        }
        else if (percent < 70 && postTest)
        {
            summaryText.text = "LEVEL CLEARED!";
            OpenCanvas();
            yield return new WaitForSeconds(0.8f);
            levelSource.clip = levelClip[1];
            levelSource.Play();
        }
        else
        {
            summaryText.text = "LEVEL CLEARED!";
            OpenCanvas();

            if (level >= PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", level + 1);
            }

            yield return new WaitForSeconds(0.8f);
            levelSource.clip = levelClip[1];
            levelSource.Play();
        }

        Debug.Log("End");
    }

    void OpenCanvas()
    {
        scoreText.text = score.ToString();
        coinText.text = (20 * score).ToString();
        
        if (postTest)
        {
            ChangeStar();
        }

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
            starImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Debug.Log("1 Star");
        }
        else
        {
            starImage.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Debug.Log("Failed");
        }
    }

    void CalculateScore()
    {
        percent = (int)Math.Round((score / maxScore) * 100f);
        Debug.Log("Percent: " + percent);

        if (percent >= 70)
        {
            currentStars = 1;
        }
        
    }

    void UpdateData()
    {
        PlayerPrefs.SetInt("Coins", coinCount + (20 * score));
        PlayerPrefs.SetInt("Totalcoin", totalCoin + (20 * score));

        if (score > PlayerPrefs.GetInt("Highscore" + level))
        {
            highScore = score;
            isHighscore = true;
            PlayerPrefs.SetInt("Highscore" + level, highScore);
        }

        if (currentStars > PlayerPrefs.GetInt("Stars" + level) && postTest)
        {
            stars = currentStars;
            PlayerPrefs.SetInt("Stars" + level, stars);
        }

    }
}

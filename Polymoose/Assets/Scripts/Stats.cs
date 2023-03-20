using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] GameObject statsPanel;
    [SerializeField] TextMeshProUGUI[] highScoreText;
    [SerializeField] TextMeshProUGUI[] playedText;
    [SerializeField] Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(OpenStats);
        buttons[1].onClick.AddListener(CloseStats);
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStats()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = PlayerPrefs.GetInt("Highscore" + i).ToString();
        }

        for (int j = 0; j < playedText.Length; j++)
        {
            playedText[j].text = PlayerPrefs.GetInt("Round" + j).ToString();
        }
    }

    void OpenStats()
    {
        StartCoroutine(DelayOpenStats());
    }

    IEnumerator DelayOpenStats()
    {
        yield return new WaitForSeconds(0.3f);
        statsPanel.SetActive(true);
    }

    void CloseStats()
    {
        StartCoroutine(DelayCloseStats());
    }

    IEnumerator DelayCloseStats()
    {
        yield return new WaitForSeconds(0.3f);
        statsPanel.SetActive(false);
    }
}

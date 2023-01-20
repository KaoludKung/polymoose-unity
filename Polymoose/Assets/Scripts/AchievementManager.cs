using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private Image[] processBar;
    [SerializeField] private Image[] imageBadge;
    [SerializeField] private GameObject[] textStatus;
    [SerializeField] private int[] achievement;
    [SerializeField] private int[] condition;

    // Start is called before the first frame update
    void Start()
    {
        
        achievement[0] = PlayerPrefs.GetInt("Firstclear");
        achievement[1] = PlayerPrefs.GetInt("Level");

        for (int i = 1; i < 6; i++)
        {
            achievement[2] += PlayerPrefs.GetInt("Stars" + i);
        }
        Debug.Log(achievement[2]);

        
        achievement[3] = PlayerPrefs.GetInt("Fullstack");
        achievement[4] = PlayerPrefs.GetInt("Totalcoin");


        for(int i = 0; i < achievement.Length; i++)
        {
            UpdateStatus(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStatus(int id)
    {
        for(int i = 0; i < achievement.Length; i++)
        {
            processBar[i].fillAmount = (float)achievement[i] / condition[i];
            Debug.Log("Achievement" + i + ": " + (float)achievement[i] / condition[i]);
        }

        if (processBar[id].fillAmount == 1)
        {
            textStatus[id].GetComponent<TextMeshProUGUI>().text = "COMPLETE";
            imageBadge[id].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            textStatus[id].GetComponent<TextMeshProUGUI>().text = achievement[id] + "/" + condition[id].ToString();
            imageBadge[id].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }

    }
}

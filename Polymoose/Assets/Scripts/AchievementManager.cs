using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private Image[] processBar;
    [SerializeField] private GameObject[] textStatus;

    [SerializeField] private int[] totalStar;
    private int firstclear;
    private int fullStack;
    private int totalCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalStar.Length; i++)
        {
            totalStar[i] = PlayerPrefs.GetInt("Stars" + (1 + (3 * i))) + PlayerPrefs.GetInt("Stars" + (2 + (3 * i))) + PlayerPrefs.GetInt("Stars" + (3 + (3 * i)));
        }

        firstclear = PlayerPrefs.GetInt("Firstclear");
        fullStack = PlayerPrefs.GetInt("Fullstack");
        totalCoin = PlayerPrefs.GetInt("Totalcoin");
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        for(int i = 0; i < totalStar.Length; i++)
        {
            processBar[i].fillAmount = (float)totalStar[i] / 9f;
        }

        processBar[5].fillAmount = (float)firstclear / 1f;
        processBar[6].fillAmount = (float)fullStack / 1f;
        processBar[7].fillAmount = (float)totalCoin / 2000f;


        for(int i = 0; i < totalStar.Length; i++)
        {
            if (processBar[i].fillAmount == 1)
            {
                textStatus[i].GetComponent<TextMeshProUGUI>().text = "COMPLETE";
            }
            else
            {
                textStatus[i].GetComponent<TextMeshProUGUI>().text = totalStar[i].ToString() + "/9";
            }
        }

        if (processBar[5].fillAmount == 1)
        {
            textStatus[5].GetComponent<TextMeshProUGUI>().text = "COMPLETE";
        }
        else
        {
            textStatus[5].GetComponent<TextMeshProUGUI>().text = "0/1";
        }

        if (processBar[6].fillAmount == 1)
        {
            textStatus[6].GetComponent<TextMeshProUGUI>().text = "COMPLETE";
        }
        else
        {
            textStatus[6].GetComponent<TextMeshProUGUI>().text = "0/1";
        }

        if (processBar[7].fillAmount == 1)
        {
            textStatus[7].GetComponent<TextMeshProUGUI>().text = "COMPLETE";
        }
        else
        {
            textStatus[7].GetComponent<TextMeshProUGUI>().text = totalCoin.ToString() + "/2000";
        }
    }

   
}

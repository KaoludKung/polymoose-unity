using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTotalStars : MonoBehaviour
{
    [SerializeField] private GameObject starText;
    private int totalStars;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            totalStars += PlayerPrefs.GetInt("Stars" + i);
        }
        
        starText.GetComponent<TextMeshProUGUI>().text = totalStars.ToString() + "/15";
        Debug.Log("TotalStar: " + totalStars);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadData : MonoBehaviour
{
    [SerializeField] private GameObject starText;
    [SerializeField] private int level;
    [SerializeField] private bool postTest;

    // Start is called before the first frame update
    void Start()
    {
        if (postTest)
        {
            int currentStar = PlayerPrefs.GetInt("Stars" + level);
            starText.GetComponent<TextMeshProUGUI>().text = currentStar.ToString() + "/1";
        }
        else
        {
            int currentStar = PlayerPrefs.GetInt("Stars" + level);
            starText.GetComponent<TextMeshProUGUI>().text = currentStar.ToString() + "/3";
        }
       
    }

}

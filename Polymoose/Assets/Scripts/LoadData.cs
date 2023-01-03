using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadData : MonoBehaviour
{
    [SerializeField] private GameObject starText;
    [SerializeField] private int level;

    // Start is called before the first frame update
    void Start()
    {
        int currentStar = PlayerPrefs.GetInt("Stars" + level); 
        starText.GetComponent<TextMeshProUGUI>().text = currentStar.ToString() + "/3";
    }

}

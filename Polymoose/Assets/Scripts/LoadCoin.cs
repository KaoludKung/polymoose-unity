using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinText;
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", coinCount);

        if (coinCount > 9999)
        {
            coinCount = 9999;
        }

        coinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
    }

}

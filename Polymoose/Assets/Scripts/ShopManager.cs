using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button itemButton1;
    [SerializeField] private Button itemButton2;
    [SerializeField] private Button itemButton3;

    private int coinCount;
    private int hintCount;
    private int freezeCount;
    private int extraCount;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", coinCount);
        hintCount = PlayerPrefs.GetInt("Hints", hintCount);
        freezeCount = PlayerPrefs.GetInt("Freezes", freezeCount);
        extraCount = PlayerPrefs.GetInt("Extratimes", extraCount);

        coinText.text = coinCount.ToString();
        Debug.Log("Coin : " + coinCount);

        itemButton1.onClick.AddListener(BuyHint);
        itemButton2.onClick.AddListener(BuyFreeze);
        itemButton3.onClick.AddListener(BuyExtraTime);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();
    }
    void BuyHint()
    {
        if (coinCount >= 50)
        {
            coinCount -= 50;
            hintCount++;

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Hints", hintCount);
            PlayerPrefs.Save();
            Debug.Log("Hints: " + hintCount);
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    void BuyFreeze()
    {
        if(coinCount >= 30)
        {
            coinCount -= 30;
            freezeCount++;

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Freezes", freezeCount);
            PlayerPrefs.Save();
            Debug.Log("Freeze Time: " + freezeCount);
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }

    void BuyExtraTime()
    {
        if (coinCount >= 40)
        {
            coinCount -= 40;
            extraCount++;

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Extratimes", extraCount);
            PlayerPrefs.Save();
            Debug.Log("Extra Time: " + extraCount);
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}

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

    /// 0 ??? ?????????????, 1 ??? ?????????????????
    [SerializeField] private AudioSource itemSource;
    [SerializeField] private AudioClip[] itemClip;

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

        if(coinCount > 9999)
        {
            coinCount = 9999;
        }

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
            itemSource.clip = itemClip[0];
            itemSource.Play();

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Hints", hintCount);
            PlayerPrefs.Save();
            Debug.Log("Hints: " + hintCount);
        }
        else
        {
            itemSource.clip = itemClip[1];
            itemSource.Play();
            Debug.Log("Not enough coins");
        }
    }

    void BuyFreeze()
    {
        if(coinCount >= 30)
        {
            coinCount -= 30;
            freezeCount++;
            itemSource.clip = itemClip[0];
            itemSource.Play();

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Freezes", freezeCount);
            PlayerPrefs.Save();
            Debug.Log("Freeze Time: " + freezeCount);
        }
        else
        {
            itemSource.clip = itemClip[1];
            itemSource.Play();
            Debug.Log("Not enough coins");
        }
    }

    void BuyExtraTime()
    {
        if (coinCount >= 40)
        {
            coinCount -= 40;
            extraCount++;
            itemSource.clip = itemClip[0];
            itemSource.Play();

            PlayerPrefs.SetInt("Coins", coinCount);
            PlayerPrefs.SetInt("Extratimes", extraCount);
            PlayerPrefs.Save();
            Debug.Log("Extra Time: " + extraCount);
        }
        else
        {
            itemSource.clip = itemClip[1];
            itemSource.Play();
            Debug.Log("Not enough coins");
        }
    }
}

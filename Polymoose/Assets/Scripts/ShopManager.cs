using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI[] countText;
    [SerializeField] private Button itemButton1;
    [SerializeField] private Button itemButton2;
    [SerializeField] private Button itemButton3;
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

        /*coinCount = 9999;
        PlayerPrefs.SetInt("Coins", coinCount);*/

        coinText.text = coinCount.ToString();
        countText[0].text = "OWNED: " + extraCount.ToString();
        countText[1].text = "OWNED: " + freezeCount.ToString();
        countText[2].text = "OWNED: " + hintCount.ToString();
        Debug.Log("Coin : " + coinCount);

        itemButton1.onClick.AddListener(BuyExtraTime);
        itemButton2.onClick.AddListener(BuyFreeze);
        itemButton3.onClick.AddListener(BuyHint);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();
        countText[0].text = "Owned: " + extraCount.ToString();
        countText[1].text = "Owned: " + freezeCount.ToString();
        countText[2].text = "Owned: " + hintCount.ToString();
    }
    void BuyHint()
    {
        if (coinCount >= 200)
        {
            coinCount -= 200;
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
        if(coinCount >= 120)
        {
            coinCount -= 120;
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
        if (coinCount >= 80)
        {
            coinCount -= 80;
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

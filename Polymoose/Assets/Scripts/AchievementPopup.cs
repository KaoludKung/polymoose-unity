using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPopup : MonoBehaviour
{
    [SerializeField] private GameObject achievementPanel;
    [SerializeField] private GameObject achievementImage;
    [SerializeField] private GameObject achievementTitle;
    [SerializeField] private GameObject achievementDetail;

    [SerializeField] private string[] titleText;
    [SerializeField] private string[] detailText;
    [SerializeField] private Sprite[] achievementSprite;
    [SerializeField] private AudioSource achievementSound;

    [SerializeField] private int[] achievementCode;
    [SerializeField] private int[] totalStar;
    [SerializeField] private float timer1;
    [SerializeField] private float timer2;

    private int firstclear;
    private int fullStack;
    private int totalCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalStar.Length; i++)
        {
            totalStar[i] = PlayerPrefs.GetInt("Stars" + (1 + (3 * i))) + PlayerPrefs.GetInt("Stars" + (2 + (3 * i))) + PlayerPrefs.GetInt("Stars" + (3 + (3 * i)));
        }

        firstclear = PlayerPrefs.GetInt("Firstclear");
        fullStack = PlayerPrefs.GetInt("Fullstack");
        totalCoin = PlayerPrefs.GetInt("Totalcoin");
        
        for(int i = 0; i < achievementCode.Length; i++)
        {
            achievementCode[i] = PlayerPrefs.GetInt("Acheivement" + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (totalStar[0] == 9 && achievementCode[0] != 12345)
        {
            StartCoroutine(TriggerAchievement(0));
        }

        if (totalStar[1] == 9 && achievementCode[1] != 12345)
        {
            StartCoroutine(TriggerAchievement(1));
        }

        if (totalStar[2] == 9 && achievementCode[2] != 12345)
        {
            StartCoroutine(TriggerAchievement(2));
        }

        if (totalStar[3] == 9 && achievementCode[3] != 12345)
        {
            StartCoroutine(TriggerAchievement(3));
        }

        if (totalStar[4] == 9 && achievementCode[4] != 12345)
        {
            StartCoroutine(TriggerAchievement(4));
        }

        if (firstclear == 1 && achievementCode[5] != 12345)
        {
            StartCoroutine(TriggerAchievement(5));
        }

        if(fullStack == 1 && achievementCode[6] != 12345)
        {
            StartCoroutine(TriggerAchievement(6));
        }

        if(totalCoin >= 2000 && achievementCode[7] != 12345)
        {
            StartCoroutine(TriggerAchievement(7));
        }
    }

    IEnumerator TriggerAchievement(int id)
    {
        switch (id)
        {
            case 0:
                achievementCode[0] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 0, achievementCode[0]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[0];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[0];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[0];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 1:
                achievementCode[1] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 1, achievementCode[1]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[1];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[1];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[1];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 2:
                achievementCode[2] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 2, achievementCode[2]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[2];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[2];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[2];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 3:
                achievementCode[3] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 3, achievementCode[3]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[3];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[3];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[3];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 4:
                achievementCode[3] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 4, achievementCode[4]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[4];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[4];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[4];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 5:
                achievementCode[5] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 5, achievementCode[5]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[5];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[5];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[5];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 6:
                achievementCode[6] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 6, achievementCode[6]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[6];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[6];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[6];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

            case 7:
                achievementCode[7] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 7, achievementCode[7]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[7];
                achievementDetail.GetComponent<TextMeshProUGUI>().text = detailText[7];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[7];

                yield return new WaitForSeconds(timer1);
                achievementPanel.SetActive(true);
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPanel.SetActive(false);
                break;

        }
    }
 
}

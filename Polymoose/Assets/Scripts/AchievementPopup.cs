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

    [SerializeField] private int[] achievement;
    [SerializeField] private int[] condition;
    [SerializeField] private int[] achievementCode;
    [SerializeField] private float timer1;
    [SerializeField] private float timer2;
    
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

        for (int i = 0; i < achievementCode.Length; i++)
        {
            achievementCode[i] = PlayerPrefs.GetInt("Acheivement" + i);
        }

        CheckAchievement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAchievement()
    {
        for (int i = 0; i < achievement.Length; i++)
        {
            if (achievement[i] >= condition[i] && achievementCode[i] != 12345)
            {
                StartCoroutine(TriggerAchievement(i));
            }
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

        }
    }
 
}

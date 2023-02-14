using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class AchievementPopup : MonoBehaviour
{
    [SerializeField] private GameObject achievementPopup;
    [SerializeField] private Image achievementPanel;
    [SerializeField] private Image achievementImage;
    [SerializeField] private TextMeshProUGUI achievementTitle;
    [SerializeField] private TextMeshProUGUI achievementName;

    [SerializeField] private string[] titleText;
    [SerializeField] private string[] detailText;
    [SerializeField] private Sprite[] achievementSprite;
    [SerializeField] private AudioSource achievementSound;

    [SerializeField] private int[] achievement;
    [SerializeField] private int[] condition;
    [SerializeField] private int[] achievementCode;
    [SerializeField] private float timer1;
    [SerializeField] private float timer2;

    [SerializeField] private int totalAchivement = 0;

    private void Awake()
    {
        //PlayerPrefs.SetInt("TotalAchievement", 4);
        //PlayerPrefs.SetInt("Acheivement" + 4, 0);

    }

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
        achievement[5] = PlayerPrefs.GetInt("TotalAchievement");

        for (int i = 0; i < achievementCode.Length; i++)
        {
            achievementCode[i] = PlayerPrefs.GetInt("Acheivement" + i);
        }

        SetAlpha();
        StartCoroutine(CheckAchievement());
    }

    IEnumerator CheckAchievement()
    {
        for (int i = 0; i < achievement.Length; i++)
        {
            if (achievement[i] >= condition[i] && achievementCode[i] != 12345)
            {
                StartCoroutine(TriggerAchievement(i));
                PlayerPrefs.SetInt("TotalAchievement", achievement[5] += 1);
                SetAlpha();
                yield return new WaitForSeconds(8);
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
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[0];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[0];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

            case 1:
                achievementCode[1] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 1, achievementCode[1]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[1];
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[1];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[1];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

            case 2:
                achievementCode[2] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 2, achievementCode[2]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[2];
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[2];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[2];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

            case 3:
                achievementCode[3] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 3, achievementCode[3]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[3];
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[3];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[3];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

            case 4:
                achievementCode[4] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 4, achievementCode[4]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[4];
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[4];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[4];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

            case 5:
                achievementCode[5] = 12345;
                PlayerPrefs.SetInt("Acheivement" + 5, achievementCode[5]);
                achievementTitle.GetComponent<TextMeshProUGUI>().text = titleText[5];
                achievementName.GetComponent<TextMeshProUGUI>().text = detailText[5];
                achievementImage.GetComponent<Image>().sprite = achievementSprite[5];

                yield return new WaitForSeconds(timer1);
                achievementPopup.SetActive(true);
                StartCoroutine(FadeAnimation());
                achievementSound.Play();

                yield return new WaitForSeconds(timer2);
                achievementPopup.SetActive(false);
                break;

        }
    }

    void SetAlpha()
    {
        achievementPanel.canvasRenderer.SetAlpha(0.0f);
        achievementImage.canvasRenderer.SetAlpha(0.0f);
        achievementTitle.canvasRenderer.SetAlpha(0.0f);
        achievementName.canvasRenderer.SetAlpha(0.0f);
    }

    IEnumerator FadeAnimation()
    {
        FadeIn();
        yield return new WaitForSeconds(3f);
        FadeOut();
    }

    void FadeIn()
    {
        achievementPanel.CrossFadeAlpha(1.0f, 1.5f, false);
        achievementImage.CrossFadeAlpha(1.0f, 1.5f, false);
        achievementTitle.CrossFadeAlpha(1.0f, 1.5f, false);
        achievementName.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        achievementPanel.CrossFadeAlpha(0.0f, 2.5f, false);
        achievementImage.CrossFadeAlpha(0.0f, 2.5f, false);
        achievementTitle.CrossFadeAlpha(0.0f, 2.5f, false);
        achievementName.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}

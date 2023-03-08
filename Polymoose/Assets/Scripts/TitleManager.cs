using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button creditButton;
    [SerializeField] Button backButton1;
    [SerializeField] Button backButton2;

    private int level;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");

        if (level == 0)
        {
            PlayerPrefs.SetInt("Level", level + 1);
        }

        tutorialButton.onClick.AddListener(OpenTutorial);
        backButton1.onClick.AddListener(CloseTutorial);

        creditButton.onClick.AddListener(OpenCredits);
        backButton2.onClick.AddListener(CloseCredits);
    }

    /// tutorial click
    void OpenTutorial()
    {
        StartCoroutine(DelayOpenTutorial());
    }

    IEnumerator DelayOpenTutorial()
    {
        yield return new WaitForSeconds(0.3f);
        tutorialPanel.SetActive(true);
    }

    void CloseTutorial()
    {
        StartCoroutine(DelayCloseTutorial());
    }

    IEnumerator DelayCloseTutorial()
    {
        yield return new WaitForSeconds(0.3f);
        tutorialPanel.SetActive(false);
    }

    /// credits click
    void OpenCredits()
    {
        StartCoroutine(DelayOpenCredits());
    }

    IEnumerator DelayOpenCredits()
    {
        yield return new WaitForSeconds(0.3f);
        creditsPanel.SetActive(true);
    }

    void CloseCredits()
    {
        StartCoroutine(DelayCloseCredits());
    }

    IEnumerator DelayCloseCredits()
    {
        yield return new WaitForSeconds(0.3f);
        creditsPanel.SetActive(false);
    }

}

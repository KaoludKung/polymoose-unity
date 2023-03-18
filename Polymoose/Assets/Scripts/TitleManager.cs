using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] Button settingButton;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button creditButton;
    [SerializeField] Button backButton1;
    [SerializeField] Button backButton2;
    [SerializeField] Button backButton3;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        settingButton.onClick.AddListener(OpenSetting);
        backButton1.onClick.AddListener(CloseSetting);

        tutorialButton.onClick.AddListener(OpenTutorial);
        backButton2.onClick.AddListener(CloseTutorial);

        creditButton.onClick.AddListener(OpenCredits);
        backButton3.onClick.AddListener(CloseCredits);
    }

    /// setting click
    void OpenSetting()
    {
        StartCoroutine(DelayOpenSetting());
    }

    IEnumerator DelayOpenSetting()
    {
        yield return new WaitForSeconds(0.3f);
        settingPanel.SetActive(true);
    }

    void CloseSetting()
    {
        StartCoroutine(DelayCloseSetting());
    }

    IEnumerator DelayCloseSetting()
    {
        yield return new WaitForSeconds(0.3f);
        settingPanel.SetActive(false);
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

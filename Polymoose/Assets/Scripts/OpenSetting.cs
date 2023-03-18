using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenSetting : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] Button settingButton;
    [SerializeField] Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        settingButton.onClick.AddListener(OpenSettings);
        backButton.onClick.AddListener(CloseSettings);
    }

  
    void OpenSettings()
    {
        StartCoroutine(DelayOpenSettings());
    }

    IEnumerator DelayOpenSettings()
    {
        yield return new WaitForSeconds(0.3f);
        settingPanel.SetActive(true);
    }

    void CloseSettings()
    {
        StartCoroutine(DelayCloseSettings());
    }

    IEnumerator DelayCloseSettings()
    {
        yield return new WaitForSeconds(0.3f);
        settingPanel.SetActive(false);
    }
}

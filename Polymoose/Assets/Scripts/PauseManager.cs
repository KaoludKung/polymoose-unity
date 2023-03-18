using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;
    [SerializeField] AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        settingsButton.onClick.AddListener(Pause);
        backButton.onClick.AddListener(Resume);
    }

  
    void Resume()
    {
        Time.timeScale = 1;
        StartCoroutine(GameResume());
    }

    IEnumerator GameResume()
    {
        yield return new WaitForSeconds(0.3f);
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        for (int i = 0; i < allAudioSources.Length; i++)
        {
            allAudioSources[i].UnPause();
        }
    }

    void Pause()
    {
        StartCoroutine(GamePause());
    }

    IEnumerator GamePause()
    {
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        for (int i = 0; i < allAudioSources.Length; i++)
        {
            allAudioSources[i].Pause();
        }
    }

}

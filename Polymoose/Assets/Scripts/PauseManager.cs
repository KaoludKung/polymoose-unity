using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;
    [SerializeField] AudioSource[] allAudioSources;
    [SerializeField] VideoPlayer[] allVideoPlayer;
    [SerializeField] private Player player;
    [SerializeField] private bool isWalk;

    // Start is called before the first frame update
    void Start()
    {
        settingsButton.onClick.AddListener(Pause);
        backButton.onClick.AddListener(Resume);
    }

  
    void Resume()
    {
        if (isWalk)
        {
            player.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
        }

        StartCoroutine(GameResume());
    }

    IEnumerator GameResume()
    {
        yield return new WaitForSeconds(0.3f);
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        allVideoPlayer = FindObjectsOfType(typeof(VideoPlayer)) as VideoPlayer[];

        for (int i = 0; i < allAudioSources.Length; i++)
        {
            allAudioSources[i].UnPause();
        }

        for(int i = 0; i < allVideoPlayer.Length; i++)
        {
            allVideoPlayer[i].playbackSpeed = 1;
        }
    }

    void Pause()
    {
        StartCoroutine(GamePause());
    }

    IEnumerator GamePause()
    {
        yield return new WaitForSeconds(0.3f);
        
        if (isWalk)
        {
            player.enabled = false;
        }
        else
        {
            Time.timeScale = 0;

        }

        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        allVideoPlayer = FindObjectsOfType(typeof(VideoPlayer)) as VideoPlayer[];

        for (int i = 0; i < allAudioSources.Length; i++)
        {
            allAudioSources[i].Pause();
        }

        for (int i = 0; i < allVideoPlayer.Length; i++)
        {
            allVideoPlayer[i].playbackSpeed = 0;
        }
    }

}

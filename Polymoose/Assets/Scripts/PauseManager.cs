using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private SideScroller sideScroller;
    
    [SerializeField] private float time;
    [SerializeField] private bool isWalk;

    private AudioSource[] allAudioSources;
    private bool showMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        mainButton.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        ShowMenu();
    }

    void Resume()
    {
        Time.timeScale = 1;
        StartCoroutine(ResumeGame());
    }

    IEnumerator ResumeGame()
    {
        yield return new WaitForSeconds(time);
        
        if (isWalk)
        {
            sideScroller.enabled = true;
        }
        
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }

        showMenu = false;
        Debug.Log("Game Running");
    }

    void Pause()
    {
        StartCoroutine(PauseGame());
    }

    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;

        if (isWalk)
        {
            sideScroller.enabled = false;
        }

        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audios in allAudioSources)
        {
            audios.Stop();
        }

        showMenu = true;
        Debug.Log("Pause Game");
    }

    void MainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(BackMainMenu());
    }

    IEnumerator BackMainMenu()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

    void ShowMenu()
    {
        if (showMenu)
        {
            pauseCanvas.SetActive(false);
            menuCanvas.SetActive(true);
        }
        else
        {
            menuCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }
    }
 
}

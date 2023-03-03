using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroFade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chapterText;
    private string scene;
    private int loading;

    private void Awake()
    {
        loading = PlayerPrefs.GetInt("Loading", loading);
        SetText(loading);
        MusicPlay.instance.GetComponent<AudioSource>().Pause();
        chapterText.canvasRenderer.SetAlpha(0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        chapterText.CrossFadeAlpha(1.0f, 2.0f, false);
        yield return new WaitForSeconds(2.0f);
        chapterText.CrossFadeAlpha(0.0f, 2.0f, false);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(scene);
    }

    void SetText(int id)
    {
        switch (id)
        {
            case 11:
                chapterText.text = "Chapter 1 <space=8em> Interview";
                scene = "Walk1";
                break;
            case 12:
                chapterText.text = "Chapter 2 <space=10em> Talking after work";
                scene = "VisualQuiz2";
                break;
            case 13:
                chapterText.text = "Chapter 3 <space=8em> Business meals";
                scene = "Walk3";
                break;
            case 14:
                chapterText.text = "Chapter 4 <space=8em> Business calling";
                scene = "Walk4";
                break;
            case 15:
                chapterText.text = "Chapter 5 <space=10em> Dealing with an angry customer";
                scene = "Walk5";
                break;
        }
    }
}

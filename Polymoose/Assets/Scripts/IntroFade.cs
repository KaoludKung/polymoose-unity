using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroFade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chapterText;
    [SerializeField] private string scene;

    private void Awake()
    {
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
}

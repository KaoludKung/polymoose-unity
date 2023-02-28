using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private string sentence;
    [SerializeField] private string sceneName;

    private int levelID;

    // Start is called before the first frame update
    void Start()
    {
        levelID = PlayerPrefs.GetInt("Loading", levelID);
        loadingText.text = string.Empty;
        LoadScene(levelID);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in sentence.ToCharArray())
        {
            loadingText.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        loadingText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    void LoadScene(int id)
    {
        switch (id)
        {
            case 1:
                SceneManager.LoadSceneAsync("VisualQuiz1");
                break;
            case 3:
                SceneManager.LoadSceneAsync("VisualQuiz3");
                break;
            case 4:
                SceneManager.LoadSceneAsync("VisualQuiz4");
                break;
            case 5:
                SceneManager.LoadSceneAsync("VisualQuiz5");
                break;
            case 6:
                SceneManager.LoadSceneAsync("Content1");
                break;
            case 7:
                SceneManager.LoadSceneAsync("Content2");
                break;
            case 8:
                SceneManager.LoadSceneAsync("Content3");
                break;
            case 9:
                SceneManager.LoadSceneAsync("Content4_New");
                break;
            case 10:
                SceneManager.LoadSceneAsync("Content5");
                break;

        }

    }
}

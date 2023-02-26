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

    // Start is called before the first frame update
    void Start()
    {
        loadingText.text = string.Empty;
        StartCoroutine(TypeLine());
        Invoke("LoadScene", 3.0f);
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

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndVisual : MonoBehaviour
{
    [SerializeField] AudioSource backgroundSound;
    [SerializeField] GameObject summaryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndScene());
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(2.0f);
        backgroundSound.Stop();
        summaryCanvas.SetActive(true);
    }
}

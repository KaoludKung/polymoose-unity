using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndVisual : MonoBehaviour
{
    [SerializeField] string scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndScene());
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
        MusicPlay.instance.GetComponent<AudioSource>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] int levelID = 0;
    [SerializeField] bool isContent;

    public void ChangeScene(string sceneName)
    {
        if (isContent)
        {
            PlayerPrefs.SetInt("Loading", levelID);
        }

        StartCoroutine(DelayScene(sceneName));
    }

    IEnumerator DelayScene(string sceneName)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] float time;
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(DelayScene(sceneName));
    }

    IEnumerator DelayScene(string sceneName)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

}

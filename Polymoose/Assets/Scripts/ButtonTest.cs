using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{

    public void OpenURL()
    {
        StartCoroutine(DelayOpenURL());
    }

    IEnumerator DelayOpenURL()
    {
        yield return new WaitForSeconds(0.3f);
        Application.OpenURL("https://forms.gle/P5j6TkdNYXoRSoao9");
    }
}

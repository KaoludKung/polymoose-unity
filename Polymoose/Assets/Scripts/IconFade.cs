using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFade : MonoBehaviour
{
    [SerializeField] GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIcon());
    }

    IEnumerator FadeIcon()
    {
        yield return new WaitForSeconds(1.2f);
        icon.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        icon.SetActive(false);
        StartCoroutine(FadeIcon());
    }
}

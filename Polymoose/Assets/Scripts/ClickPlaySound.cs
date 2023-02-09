using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickPlaySound : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] AudioSource speechSource;
    [SerializeField] AudioClip speechClip;
    [SerializeField] private string[] sentences;
    private int index = 0;

    public void StartSpeech()
    {
        textComponent.text = string.Empty;
        PlaySound();
        StartCoroutine(TypeLine());
    }

    private void PlaySound()
    {
        speechSource.clip = speechClip;
        speechSource.Play();
    }

    IEnumerator TypeLine()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
    }
    
}

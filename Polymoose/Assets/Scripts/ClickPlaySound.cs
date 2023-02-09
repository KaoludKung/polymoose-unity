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
    [SerializeField] private bool isTyping;

    private bool isEnd = false;
    private int index = 0;

    public void StartSpeech()
    {
        if (!isEnd)
        {
            if (isTyping)
            {
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            PlaySound();
        }
        
    }

    private void PlaySound()
    {
        speechSource.clip = speechClip;
        speechSource.Play();
    }

    IEnumerator TypeLine()
    {
        isEnd = true;

        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(0.06f);
        }

        yield return new WaitForSeconds(0.5f);
        isEnd = false;
    }
    
}

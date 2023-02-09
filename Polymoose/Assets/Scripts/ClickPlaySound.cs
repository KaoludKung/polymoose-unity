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
    [SerializeField] private bool isVocab;

    private bool isEnd = false;
    private int index = 0;

    public void StartSpeech()
    {
        if (!isEnd)
        {
            if (isTyping)
            {
                textComponent.text = string.Empty;
                textComponent.color = new Color32(84, 194, 60, 255);
                StartCoroutine(TypeLine());
                PlaySound();
            }
            else
            {
                if (isVocab)
                {
                    StartCoroutine(VocabColor());
                }

                PlaySound();
            }
        }
        else
        {
            StopAllCoroutines();
            speechSource.Stop();
            textComponent.text = sentences[index];
            textComponent.color = new Color32(255, 255, 255, 255);
            isEnd = false;
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
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);
        textComponent.color = new Color32(255, 255, 255, 255);
        isEnd = false;
    }

    IEnumerator VocabColor()
    {
        textComponent.color = new Color32(84, 194, 60, 255);
        speechSource.clip = speechClip;
        speechSource.Play();
        
        yield return new WaitForSeconds(speechClip.length);
        textComponent.color = new Color32(255, 255, 255, 255);
    }
    
}

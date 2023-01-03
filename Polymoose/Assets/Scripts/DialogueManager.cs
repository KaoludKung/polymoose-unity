using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject currentSet;
    [SerializeField] private GameObject nameNpc;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private GameObject nextSet;

    [SerializeField] private string[] sentences;
    [SerializeField] private string Name;
    [SerializeField] private float textSpeed;

    [SerializeField] private AudioSource talkSource;
    [SerializeField] private AudioClip[] talkClip;
    
    private int index;
    private bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        nameNpc.GetComponent<TextMeshProUGUI>().text = Name;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == sentences[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = sentences[index];
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;

        if (isTalking)
        {
            index = 0;
            nameNpc.SetActive(true);
            StartCoroutine(PlaySound());
            StartCoroutine(TypeLine());
        }
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.5f);
        talkSource.clip = talkClip[index];
        talkSource.Play();
    }

    void NextLine()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(PlaySound());
            StartCoroutine(TypeLine());
        }
        else
        {
            isTalking = false;
            currentSet.SetActive(false);
            nextSet.SetActive(true);
        }
    }
}

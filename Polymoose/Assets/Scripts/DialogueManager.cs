using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject nameNpc;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject nextSet;

    [SerializeField] private string[] sentences;
    [SerializeField] private GameObject iconNpc;
    [SerializeField] private Sprite spriteNpc;
    [SerializeField] private AudioClip[] talkClip;
    [SerializeField] private AudioSource talkSource;
    
    [SerializeField] private string Name;
    [SerializeField] private float textSpeed;
    
    private int index;
    private bool isTalking;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        nameNpc.GetComponent<TextMeshProUGUI>().text = Name;
        iconNpc.GetComponent<Image>().sprite = spriteNpc;
        Invoke("StartDialogue", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI("Settings"))
        {
            if (textComponent.text == sentences[index] && nextButton.activeSelf)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = sentences[index];
                talkSource.Stop();
                nextButton.SetActive(true);
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
            PlaySound();
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

        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
    }

    void PlaySound()
    {
        talkSource.clip = talkClip[index];
        talkSource.Play();
    }

    void NextLine()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            nextButton.SetActive(false);
            textComponent.text = string.Empty;
            PlaySound();
            StartCoroutine(TypeLine());
        }
        else
        {
            isTalking = false;
            Destroy(gameObject);
            nextSet.SetActive(true);
        }
    }

    public static bool IsPointerOverUI(string tag)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        
        foreach (RaycastResult raysastResult in raysastResults)
        {
            if (raysastResult.gameObject.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}

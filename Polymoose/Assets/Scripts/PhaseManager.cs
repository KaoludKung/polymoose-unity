using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private GameObject firstDialogue;
    [SerializeField] private GameObject textObjective;
    [SerializeField] private SideScroller sideScroller;
    [SerializeField] private bool walkPhase;

    [SerializeField] private float time1;
    [SerializeField] private float time2;

    // Start is called before the first frame update
    void Start()
    {
        if (walkPhase)
        {
            StartCoroutine(SetObjective());
        }
        else
        {
            firstDialogue.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetObjective()
    {
        yield return new WaitForSeconds(time1);
        textObjective.SetActive(true);
        yield return new WaitForSeconds(time2);
        textObjective.SetActive(false);
        sideScroller.enabled = true;
    }
}

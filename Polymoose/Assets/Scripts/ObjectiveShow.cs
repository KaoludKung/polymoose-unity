using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveShow : MonoBehaviour
{
    [SerializeField] GameObject Objective;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] string message;

    private void Awake()
    {
        objectiveText.text = message;
        objectiveText.canvasRenderer.SetAlpha(0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator FadeAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.SetActive(true);
        objectiveText.CrossFadeAlpha(1.0f, 3.0f, false);
        yield return new WaitForSeconds(4.0f);
        objectiveText.CrossFadeAlpha(0.0f, 3.5f, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveShow : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject Objective;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] TextMeshProUGUI tapText;
    [SerializeField] GameObject[] arrow;
    [SerializeField] string message;

    private void Awake()
    {
        objectiveText.text = message;
        objectiveText.canvasRenderer.SetAlpha(0.0f);
        tapText.canvasRenderer.SetAlpha(0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAnimation());
    }

    IEnumerator FadeAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        Objective.SetActive(true);
        objectiveText.CrossFadeAlpha(1.0f, 2.0f, false);
        tapText.CrossFadeAlpha(1.0f, 2.0f, false);

        yield return new WaitForSeconds(5.0f);
        objectiveText.CrossFadeAlpha(0.0f, 2.0f, false);
        tapText.CrossFadeAlpha(0.0f, 2.0f, false);
        
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(ArrowAlert());
        player.enabled = true;
    }

    IEnumerator ArrowAlert()
    {
        for(int i =0; i < 2; i++)
        {
            yield return new WaitForSeconds(1.5f);
            arrow[0].SetActive(true);
            //arrow[1].SetActive(true);
            yield return new WaitForSeconds(2.5f);
            arrow[0].SetActive(false);
            //arrow[1].SetActive(false);
            
        }
    }
}

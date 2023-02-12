using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveShow : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject Objective;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] TextMeshProUGUI tapText;
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
        yield return new WaitForSeconds(0.5f);
        Objective.SetActive(true);
        objectiveText.CrossFadeAlpha(1.0f, 2.0f, false);
        tapText.CrossFadeAlpha(1.0f, 2.0f, false);

        yield return new WaitForSeconds(3.0f);
        objectiveText.CrossFadeAlpha(0.0f, 3.0f, false);
        tapText.CrossFadeAlpha(0.0f, 3.0f, false);
        player.enabled = true;
    }
}

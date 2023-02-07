using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreFade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;
   
    private void Awake()
    {
        highscore.canvasRenderer.SetAlpha(0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        highscore.CrossFadeAlpha(1.0f, 1.5f, true);
        yield return new WaitForSeconds(1.5f);
        highscore.CrossFadeAlpha(0.0f, 1.5f, true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Fade());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] Button creditButton;
    [SerializeField] Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        creditButton.onClick.AddListener(OpenCredits);
        backButton.onClick.AddListener(CloseCredits);
    }

    void OpenCredits()
    {
        StartCoroutine(DelayOpenCredits());
    }

    IEnumerator DelayOpenCredits()
    {
        yield return new WaitForSeconds(0.3f);
        creditsPanel.SetActive(true);
    }

    void CloseCredits()
    {
        StartCoroutine(DelayCloseCredits());
    }

    IEnumerator DelayCloseCredits()
    {
        yield return new WaitForSeconds(0.3f);
        creditsPanel.SetActive(false);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

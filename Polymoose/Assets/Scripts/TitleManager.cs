using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] Button startButton;
    [SerializeField] Button creditButton;
    [SerializeField] Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(MainMenu);
        creditButton.onClick.AddListener(OpenCredits);
        backButton.onClick.AddListener(CloseCredits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    void CloseCredits()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SummaryManager : MonoBehaviour
{
    public GameObject summaryCanvas;
    public GameObject currentCanvas;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public TextMeshProUGUI summaryText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI coinText;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(Retry);
        menuButton.onClick.AddListener(Menu);
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}

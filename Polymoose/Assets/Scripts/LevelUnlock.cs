using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] int levelRequirement;
    [SerializeField] GameObject titleName;
    [SerializeField] GameObject startext;
    [SerializeField] GameObject starImage;
    

    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("Level");
        bool levelUnlocked = currentLevel >= levelRequirement;
        GetComponent<Button>().interactable = levelUnlocked;

        if (levelUnlocked)
        {
            titleName.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1f);
            startext.GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 1f);
            starImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            titleName.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 0.5f);
            startext.GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 0.5f);
            starImage.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }

}

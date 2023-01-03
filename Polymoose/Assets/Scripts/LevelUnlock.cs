using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] int levelRequirement;

    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("Level");
        bool levelUnlocked = currentLevel >= levelRequirement;
        GetComponent<Button>().interactable = levelUnlocked;
        Debug.Log(currentLevel);
    }

}

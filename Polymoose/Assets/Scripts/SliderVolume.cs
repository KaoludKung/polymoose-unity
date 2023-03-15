using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider talkingSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music") && !PlayerPrefs.HasKey("Talking"))
        {
            PlayerPrefs.SetFloat("Music", 0.2f);
            PlayerPrefs.SetFloat("Taling", 8.0f);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Save();
    }


    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Music");
        talkingSlider.value = PlayerPrefs.GetFloat("Talking");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("Music", volumeSlider.value);
        PlayerPrefs.SetFloat("Talking", talkingSlider.value);
    }
}

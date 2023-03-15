using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int soundID;
    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music") && !PlayerPrefs.HasKey("Talking"))
        {
            PlayerPrefs.SetFloat("Music", 0.2f);
            PlayerPrefs.SetFloat("Taling", 1.0f);
            Load(soundID);
        }
        else
        {
            Load(soundID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Load(soundID);
    }

    void Load(int id)
    {
        switch (id)
        {
            case 1:
                volume = PlayerPrefs.GetFloat("Music");
                break;
            case 2:
                volume = PlayerPrefs.GetFloat("Talking");
                break;
        }
        
        audioSource.volume = volume;
    }

}

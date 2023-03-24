using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMusic : MonoBehaviour
{
    
    void Start()
    {
        if (PlayerPrefs.GetInt("IsPlayed") == 1)
        {
            MusicPlay.instance.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("IsPlayed", 0);
            Debug.Log(PlayerPrefs.GetInt("IsPlayed"));
        }
    }

    public void PlayMusic()
    {
        MusicPlay.instance.GetComponent<AudioSource>().Play();
    }

}

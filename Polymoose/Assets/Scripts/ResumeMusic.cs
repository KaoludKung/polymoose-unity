using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMusic : MonoBehaviour
{
    public void PlayMusic()
    {
        MusicPlay.instance.GetComponent<AudioSource>().Play();
    }
}

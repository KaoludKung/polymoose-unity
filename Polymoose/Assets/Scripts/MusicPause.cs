using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicPlay.instance.GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        MusicPlay.instance.GetComponent<AudioSource>().Stop();
    }
}

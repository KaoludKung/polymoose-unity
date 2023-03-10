using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Networking;



public class VideoAlpha : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;
    [SerializeField] private VideoPlayer videoPlayer;
    public bool isPlay;
    private bool isStop = false;

    private void Awake()
    {
        videoImage.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        videoPlayer.Prepare();
    }

    void Update()
    {
        if (isPlay)
        {
            PlayVideo();
            isStop = true;
        }
    }

    void PlayVideo()
    {
        if (!isStop)
        {
            videoImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            videoPlayer.Play();
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoAlpha : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float time;
    
    public bool isPlay;
    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.Prepare();
        videoImage.color = new Color(1.0f, 1.0f, 1.0f, 0f);
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

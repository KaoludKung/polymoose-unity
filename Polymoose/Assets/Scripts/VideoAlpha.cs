using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VideoAlpha : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;
    [SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetAlpha", time);
    }

    void SetAlpha()
    {
        videoImage.color = new Color(1.0f, 1.0f, 1.0f, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private AudioSource speechSource;

    public void StopSound()
    {
        speechSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private float time;
    [SerializeField] bool isFalse;

    // Start is called before the first frame update
    void Start()
    {
        MusicPlay.instance.GetComponent<AudioSource>().Stop();
        StartCoroutine(Active());
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(time);
        
        if (isFalse)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
        
    }
}

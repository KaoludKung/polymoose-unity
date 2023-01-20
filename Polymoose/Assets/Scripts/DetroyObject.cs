using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyObject : MonoBehaviour
{
    [SerializeField] private GameObject currentObject;
    [SerializeField] private GameObject nextObject;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(currentObject);
        nextObject.SetActive(true);
    }

}

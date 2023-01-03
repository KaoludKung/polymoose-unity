using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollBar;
    float scrollPosition = 0;
    float[] position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = new float[transform.childCount];
        float distance = 1f / (position.Length - 1);

        for(int i = 0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) 
        {
            scrollPosition = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < position.Length; i++)
            {
                if(scrollPosition < position[i] + (distance / 2) && scrollPosition > position[i] - (distance / 2))
                {
                    scrollPosition = scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, position[i], 0.1f);
                }
            }
        }

    }
}

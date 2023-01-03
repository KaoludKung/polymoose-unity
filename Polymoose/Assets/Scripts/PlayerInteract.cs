using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private SideScroller sideScroller;
    [SerializeField] private GameObject icon;
    private GameObject currentObject = null;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interact"))
        {
            currentObject = collision.gameObject;
            icon.SetActive(true);
            sideScroller.isInteract = true;
            Debug.Log(collision.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interact"))
        {
           if(collision.gameObject == currentObject)
            {
                icon.SetActive(false);
                sideScroller.isInteract = false;
                currentObject = null;
            }
        }
    }
}

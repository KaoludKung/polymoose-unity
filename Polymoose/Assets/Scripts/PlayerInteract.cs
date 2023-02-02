using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject icon;
    private GameObject currentObject = null;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interact"))
        {
            currentObject = collision.gameObject;
            StartCoroutine(FadeIcon());
            player.isInteract = true;
            Debug.Log(collision.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interact"))
        {
           if(collision.gameObject == currentObject)
            {
                StopAllCoroutines();
                icon.SetActive(false);
                player.isInteract = false;
                currentObject = null;
            }
        }
    }

    IEnumerator FadeIcon()
    {
        yield return new WaitForSeconds(1.2f);
        icon.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        icon.SetActive(false);
        StartCoroutine(FadeIcon());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private int number;

    public void ShowText()
    {
        Debug.Log("Level" + number);
    }
}

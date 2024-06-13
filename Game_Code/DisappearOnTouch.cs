using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if it's player
        if (other.CompareTag("Player"))
        {
            // object disapper
            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAndChangeMusic : MonoBehaviour
{
    public GameObject targetObject; 
    public AudioSource musicPlayer; 
    public AudioClip newMusicClip; 
    public float triggerDistance = 3f; 
    private bool hasTriggered = false; // check if audio played

    void Update()
    {
        // if had played,return and over
        if (hasTriggered) return;

        // caculate the distance with player and object
        float distance = Vector3.Distance(Camera.main.transform.position, targetObject.transform.position);

        // if the distance with player and object <triggrt distance
        if (distance <= triggerDistance && !hasTriggered)
        {
            // not show the object
            targetObject.SetActive(false);

            // stop current music and change to other music
            musicPlayer.Stop(); // sure music stoped
            musicPlayer.clip = newMusicClip; // change the music
            musicPlayer.Play(); //start new music

            // prevent repeat triggers
            hasTriggered = true;
        }
    }
}
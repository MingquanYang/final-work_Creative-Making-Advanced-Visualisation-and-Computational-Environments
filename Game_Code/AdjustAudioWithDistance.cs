using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AdjustAudioWithDistance : MonoBehaviour
{
    public Transform player; 
    private AudioSource audioSource; 

    public float maxVolumeDistance = 5f; 
    public float minVolumeDistance = 20f; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // star the audio
    }

    void Update()
    {
        // distance with player and object
        float distance = Vector3.Distance(player.position, transform.position);

        // adjust the audio volume when distance change
        if (distance < minVolumeDistance)
        {
            audioSource.volume = Mathf.Lerp(1.0f, 0f, (distance - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance));
        }
        else
        {
            audioSource.volume = 0; // if player doesn't on the min distance,audio volume become 0
        }
    }
}

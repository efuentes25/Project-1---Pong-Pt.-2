using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip bonkSound, playerScoreSound;
    
    public Trigger leftTrigger;
    public Trigger RightTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (audioSource.clip != bonkSound)
        {
            audioSource.clip = bonkSound;
        }
        audioSource.Play();
    }

    public void OnTrigger(Trigger trigger)
    {
        if (leftTrigger == trigger)
        {
            audioSource.clip = playerScoreSound;
            audioSource.Play();
        } 
        else if (RightTrigger == trigger)
        {
            audioSource.clip = playerScoreSound;
            audioSource.Play();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// credit to Michael Guerrero

public class Trigger : MonoBehaviour
{
    public Game manager;
    public BallSound sound;
    
    private void OnTriggerEnter(Collider other)
    {
        manager.OnTrigger(this);
        sound.OnTrigger(this);
    }
}

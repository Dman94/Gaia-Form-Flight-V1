using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Laser;
    ParticleSystem emitter;
    int index;


     void Update()
    {
     
            
    }
    //Play a new instance of the audioclip on each particle emitted
    //How do we go about this? what do we need to know to instruct?
    // check for each new particle emitted and on each one play the auido clip from the beginning
    // how do we check for each new particle emitted?


}

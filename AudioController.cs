using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClipControls audio;
    public AudioSource interruptionAudio;

    void Update()
    {

         if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audio.VolumeTransition(1.0f, 3.0f);            
        }

         if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            audio.VolumeTransition(0.01f, 0.5f);
            interruptionAudio.Play();
        }
        
    }
}

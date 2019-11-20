using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControllerScript : MonoBehaviour
{
    public VideoAudioControl audio;
    public GameObject videoPlayer; 
    public GameObject text;

    float lower = 0.125f;
    float mid = 0.5f;
    float upper = 1.0f;

    float t = 0.5f;

    float w = 9.0f;

    double vpAudio = 0.0;

    void Awake ()
    {
        videoPlayer.GetComponent<AudioSource>().volume = mid;
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audio.VolumeTransition(lower, t, mid, w);        
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audio.VolumeTransition(upper, t, mid, w);    
        }

/*       
        // if (OVRInput.Get(OVRInput.Button.One))
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (vpAudio > mid)
            {
                audio.VolumeTransition(mid, t);
                vpAudio = mid;
            } else {
                audio.VolumeTransition(lower, t);
                vpAudio = lower;
            } 
        }

        // if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (vpAudio < mid)
            {
                audio.VolumeTransition(mid, t);
                vpAudio = mid;
            } else {
                audio.VolumeTransition(upper, t);
                vpAudio = upper;
            }                   
        }
*/        
        if (OVRInput.Get(OVRInput.Button.Back))
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            videoPlayer.GetComponent<VideoPlayer>().Play();
            text.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

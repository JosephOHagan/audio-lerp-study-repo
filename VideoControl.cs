using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class VideoControl : MonoBehaviour
{
    public GameObject vObject;
    public VideoClip[] vcList;
    public AudioClip[] acList;
    public int count;   

    bool firstPlayed = false; 
    bool paused = false;

    public GameObject text;

    // Update is called once per frame
    void Update()
    {
        if (count <= 5  && firstPlayed)
        {
            if (!vObject.GetComponent<VideoPlayer>().isPlaying && !paused)
            {                
                vObject.GetComponent<VideoPlayer>().enabled = false;
                text.GetComponent<MeshRenderer>().enabled = true;
                if (count < 5){
                    vObject.GetComponent<VideoPlayer>().clip = vcList[count];
                    vObject.GetComponent<AudioSource>().clip = acList[count];
                }                
                count += 1;
                paused = true;
                vObject.GetComponent<VideoPlayer>().enabled = true;
            }
        }

        if (vObject.GetComponent<VideoPlayer>().isPlaying && !firstPlayed)    
        {
            firstPlayed = true;
        }

        if (vObject.GetComponent<VideoPlayer>().isPlaying)
        {
            paused = false;
        }
    }
}
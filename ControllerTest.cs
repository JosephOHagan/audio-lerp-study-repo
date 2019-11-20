using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour
{

    public Material mat1;
    public Material mat2;
    public Material mat3;
    public GameObject change;
    public GameObject audio;
    double vpAudio;

    void Awake()
    {
        vpAudio = audio.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (vpAudio == 1.0)
        {
            change.GetComponent<Renderer>().material = mat1;
        }
        else if (vpAudio < 0.1)
        {
            change.GetComponent<Renderer>().material = mat3;
        }
        else
        {
            change.GetComponent<Renderer>().material = mat2;
        }
        
        vpAudio = audio.GetComponent<AudioSource>().volume;    
        // Debug.Log(vpAudio.ToString("#.00"));

    }
}

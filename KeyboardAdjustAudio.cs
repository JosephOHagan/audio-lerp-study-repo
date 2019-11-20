using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAdjustAudio : MonoBehaviour
{
    public AudioSource aSource;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (aSource.volume < 1)
            {
                aSource.volume += 0.1f;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (aSource.volume > 0)
            {
                aSource.volume -= 0.1f;
            }
        }

    }
}

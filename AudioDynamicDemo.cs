using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDynamicDemo : MonoBehaviour
{

    public AudioSource aSource;                 // Audio Source (gameplay)
    public AudioSource iSource;                 // Interruption Source (person interrupting)

    // Timer to play second audio source on a delay    
    private IEnumerator coroutineTimer;
    private int coroutineTrigger = 0;

    void Start()
    {
        iSource.PlayDelayed(5.0f);

        // Because demo triggger interruption after 5 seconds so start timer
        coroutineTimer = WaitAndTrigger(5.0f);
        StartCoroutine(coroutineTimer);
    }

    void Update()
    {    
        if (coroutineTrigger == 1)
        {
            coroutineTrigger += 1;
        }

    }

    private IEnumerator WaitAndTrigger(float waitTime)
    {
        while (coroutineTrigger == 0)
        {
            yield return new WaitForSeconds(waitTime);
            coroutineTrigger += 1;   
        }
    }
    
}

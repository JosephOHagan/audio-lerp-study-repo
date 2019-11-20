using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAudioControl : MonoBehaviour
{
    public GameObject t;
    AudioSource audio;
    IEnumerator volumeCoroutine;  // coroutines transitioning volume are handed to this variable
    IEnumerator waitCoroutine;
    IEnumerator riseCoroutine; 

    public float volume
    {
        get { return audio.volume; }
        private set { }
    }

    // check these to find where pitch and volume are headed in case of interrupting a transition
    public float targetVolume { get; private set; }


    void Awake()
    {
        audio = t.GetComponent<AudioSource>();
        targetVolume = audio.volume;
    }

    // call this function to set volume directly, killing the volume transition taking place first
    public void SetVolume(float volume)
    {
        targetVolume = volume;

        if (volumeCoroutine != null)
        {
            StopCoroutine(volumeCoroutine);
        }

        audio.volume = volume;
    }

    // change volume to target frequency over duration seconds
    public void VolumeTransition(float target, float duration, float original, float wait)
    {
        // set targetPitch variable to allow access to desired pitch to any object modifying it while coroutine is active
        targetVolume = target;

        // stop any volume transitions before starting a new one
        if (volumeCoroutine != null)
        {
            StopCoroutine(volumeCoroutine);
        }

        // if duration is a very small number just set volume directly
        // avoids potential division by 0
        if (duration <= Mathf.Epsilon && duration > 0)
        {
            SetVolume(target);
        }
        else
        {
            // assign transition to variable, then start the coroutine
            volumeCoroutine = VolumeTransitionCoroutine(target, duration);
            StartCoroutine(volumeCoroutine);
            
            waitCoroutine = WaitCoroutine(wait, original, duration);
            StartCoroutine(waitCoroutine);            
        }
    }

    // Coroutine for transitioning volume, run by calling VolumeTransition
    IEnumerator VolumeTransitionCoroutine(float target, float duration)
    {
        float from = audio.volume;
        float invDuration = 1.0f / duration;

        // the "counter" variable to track position within Lerp
        float progress = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(audio.volume - target) > 0.0f)
        {
            audio.volume = Mathf.Lerp(from, target, progress);
            progress += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }

    IEnumerator WaitCoroutine(float wait, float original, float duration)
    {
        yield return new WaitForSeconds(wait);
        riseCoroutine = VolumeTransitionCoroutine(original, duration);
        StartCoroutine(riseCoroutine);
    }
}

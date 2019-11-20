using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAudioTest : MonoBehaviour
{
    public AudioSource aSource;

    void Awake() {
        aSource.volume = 0.0f;
    }
    
    void Start()
    {
        StartCoroutine(FadeMusic(1.0f, 50000000.0f));
    }

    private IEnumerator FadeMusic(float targetVolume, float duration)
    {
        float startVolume = aSource.volume;
        float inverseDuration = 1.0f / duration;
        float lerpFactor = 0.0f;
   
        while (lerpFactor <= 1.0f) {
            aSource.volume = Mathf.Lerp(startVolume, targetVolume, lerpFactor);
            lerpFactor = lerpFactor + Time.deltaTime * inverseDuration;
        }
        aSource.volume = targetVolume;
        yield return 0.4f;
    }

}

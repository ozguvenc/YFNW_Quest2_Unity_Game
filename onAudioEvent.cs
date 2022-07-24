using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAudioEvent : MonoBehaviour
{
    public AudioSource objectAudioSource;
    public Animator objectAnimator;
    public AudioClip audioClip_1;
    public AudioClip audioClip_2;
    public AudioClip audioClip_3;
    // Start is called before the first frame update
    void Start()
    {
        objectAudioSource = gameObject.GetComponent<AudioSource>();
        objectAnimator = gameObject.GetComponent<Animator>();
    }

    public void audioEvent_1()
    {
        
        
            objectAudioSource.Stop();
            objectAudioSource.loop = false;
            objectAudioSource.clip = audioClip_1;
            objectAudioSource.volume = 1f;
            objectAudioSource.Play();
            Debug.Log("audioEvent_1 Played");

    }
    public void audioEvent_2()
    {

            objectAudioSource.Stop();
            objectAudioSource.loop = false;
            objectAudioSource.clip = audioClip_2;
            objectAudioSource.volume = 1f;
            objectAudioSource.Play();
            Debug.Log("audioEvent_2 Played");
    }

    public void audioEvent_3()
    {
        if (objectAudioSource.clip != audioClip_3)
        {
            objectAudioSource.Stop();
            objectAudioSource.loop = true;
            objectAudioSource.clip = audioClip_3;
            objectAudioSource.volume = 1f;
            objectAudioSource.Play();
            Debug.Log("audioEvent_3 Played");
        }
    }

}

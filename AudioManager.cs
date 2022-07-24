using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ambiance;
    public AudioClip uiSound;
    public float ambianceVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = ambiance;
        audioSource.loop = true;
        audioSource.volume = ambianceVolume;
        audioSource.Play();
    }
}

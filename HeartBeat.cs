using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public AudioSource source;
    public AudioClip heartBeatClip;


    public void HeartBeatSound()
    {
        source.clip = heartBeatClip;
        source.PlayOneShot(heartBeatClip);
    }

}

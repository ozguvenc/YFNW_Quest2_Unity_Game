using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public AudioClip bounceSound;

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider

    private int counter = 0;
    
    private void OnCollisionEnter(Collision collision)
    {
        counter++;

        if (collision.gameObject.layer == 9 && counter!=1)
            gameObject.GetComponent<AudioSource>().PlayOneShot(bounceSound);
    }


}

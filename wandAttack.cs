using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandAttack : MonoBehaviour
{
    public bool deathSequeneStarted;
    public GameObject wandEffect;
    public GameObject effectSpawnPoint;
    public bool holdingObject;
    public GameObject rightHand;
    public GameObject droppedObjects;


    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        holdingObject = false;
        deathSequeneStarted = false;
    }



    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (holdingObject)
        {
            Instantiate(wandEffect, effectSpawnPoint.transform.position, Quaternion.identity);
        }
        

        AudioSource source = other.gameObject.GetComponent<AudioSource>();


        if (other.gameObject.CompareTag("Enemy") && deathSequeneStarted == false)
            
        {
            StartCoroutine(DeathSequence(5, other, source));
        }

    }

    IEnumerator DeathSequence(float duration, Collider other, AudioSource source)
    {
        deathSequeneStarted = true
            ;
        gameObject.GetComponent<AudioSource>().Play();

        other.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        other.gameObject.GetComponent<Animator>().Play("Standing_React_Death_Backward");

        other.gameObject.GetComponent<attackBehavior>().blocker.SetActive(false);

        //other.gameObject.GetComponent<Animator>().SetTrigger("Death_backward");
        source.Play();

        yield return new WaitForSeconds(duration);
        Instantiate(other.gameObject.GetComponent<attackBehavior>().deathParticle, other.gameObject.GetComponent<attackBehavior>().deathParticlePosition.transform.position, Quaternion.identity);
        Destroy(other.gameObject);

        deathSequeneStarted = false;
    }


    public void HoldObject()
    {
        StartCoroutine(WaitBeforeEffect(1));
    }

    public void DropObject()
    {
        holdingObject = false;
        transform.parent = droppedObjects.transform;
    }


    IEnumerator WaitBeforeEffect(float time)
    {
        yield return new WaitForSeconds(time);
        holdingObject = true;
        transform.parent = rightHand.transform;
    }
}

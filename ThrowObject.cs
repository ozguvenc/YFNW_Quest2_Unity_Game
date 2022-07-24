using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    public GameObject throwPoint;
    public GameObject parentObject;
    public GameObject heldObject;
    public AudioSource source;
    public AudioClip swingSound;
    public float targetDistance;
    public float attackDistance;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = (transform.position - target.transform.position).magnitude;
        if(targetDistance <= attackDistance)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack4");
        }
    }

    public void Throw()
    {
        Instantiate(projectile, throwPoint.transform.position, throwPoint.transform.rotation, parentObject.transform);
        heldObject.SetActive(false);
        source.PlayOneShot(swingSound);
    }

    public void Reload()
    {
        heldObject.SetActive(true);
    }
}

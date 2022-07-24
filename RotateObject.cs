using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public bool startRotation;
    public Vector3 rotationAxis;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startRotation)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }
}

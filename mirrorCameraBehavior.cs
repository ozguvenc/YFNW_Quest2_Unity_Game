using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorCameraBehavior : MonoBehaviour
{
    public GameObject vrCamera;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float turnCoefficient;
    public GameObject mirrorLookAtTarget;
    public float zMin, zMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.LookAt(mirrorLookAtTarget.transform.position, transform.up);
        gameObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        float mirrorDistance = (mirrorLookAtTarget.transform.position.z + (mirrorLookAtTarget.transform.position.z - vrCamera.transform.position.z)) + zOffset;
        mirrorDistance = Mathf.Clamp(mirrorDistance, zMin, zMax);

        gameObject.transform.position = new Vector3(vrCamera.transform.position.x + xOffset, vrCamera.transform.position.y + yOffset, mirrorDistance);
    }
}

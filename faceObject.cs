using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceObject : MonoBehaviour
{
    public GameObject objectToFace;
    public Vector3 targetModified;
    public Vector3 rotationAxis;
    public float xOffset, yOffset, zOffset;

    // Update is called once per frame
    void Update()
    {
        rotationAxis = new Vector3(rotationAxis.x + xOffset, rotationAxis.y + yOffset, rotationAxis.z + zOffset);

        targetModified = new Vector3(objectToFace.transform.position.x, transform.position.y, objectToFace.transform.position.z);

        transform.LookAt(targetModified, rotationAxis);
    }
}

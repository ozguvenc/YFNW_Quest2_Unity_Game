using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadOrientation : MonoBehaviour
{
    public GameObject vrCamera;
    public GameObject bodyOrientation;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float turnCoefficient;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(
           ( vrCamera.transform.eulerAngles.z) + zOffset + bodyOrientation.transform.eulerAngles.z,
           ( vrCamera.transform.eulerAngles.y) + yOffset + bodyOrientation.transform.eulerAngles.y, 
           (- vrCamera.transform.eulerAngles.x) + xOffset + bodyOrientation.transform.eulerAngles.x
        );
    }
}

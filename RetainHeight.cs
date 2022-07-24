using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetainHeight : MonoBehaviour
{
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }
}

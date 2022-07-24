using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        Instantiate(particles, transform.position, transform.rotation);
    }


}

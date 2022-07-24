using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeleportParticles : MonoBehaviour
{
    public GameObject particles;
    public float xOffset;
    public float yOffset;
    public float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTeleportationParticles()
    { 
        
        GameObject reticle = GameObject.FindGameObjectWithTag("Teleportation");
     
        if(reticle != null) { 
        
            Vector3 particlePosition = new Vector3(reticle.transform.position.x, reticle.transform.position.y, reticle.transform.position.z);
        
            Quaternion particleRotation = new Quaternion(reticle.transform.rotation.eulerAngles.x + xOffset, reticle.transform.rotation.y + yOffset, reticle.transform.rotation.z + zOffset, reticle.transform.rotation.w);
        
            Instantiate(particles, particlePosition, particleRotation);
    
        }
    }
}

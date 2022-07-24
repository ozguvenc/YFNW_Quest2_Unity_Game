using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject heldHeart;
    public GameObject staticHeart;
    public GameObject gate;
    public GameObject blocker;
    public AudioClip openGate;
    public GameObject blocker2;
    public GameObject field;
    public GameObject Nitya;


    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Heart")
        {
            staticHeart.SetActive(true);
            Destroy(heldHeart);
            gate.GetComponent<Animator>().Play("Open Gate");
            gate.GetComponent<AudioSource>().PlayOneShot(openGate);
            Destroy(blocker);
            Destroy(blocker2);
            Destroy(field);
            Nitya.GetComponent<MeshRenderer>().materials.SetValue(null, 1);
        }

    }




}

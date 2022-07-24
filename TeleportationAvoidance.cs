using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationAvoidance : MonoBehaviour
{
    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dark"))
        {
            GetComponent<XRRayInteractor>().enabled = false;
        }
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dark"))
        {
            GetComponent<XRRayInteractor>().enabled = true;
        }
    }
}

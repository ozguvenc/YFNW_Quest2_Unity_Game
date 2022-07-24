using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallAvoidance : MonoBehaviour
{
    public Image fade;


    // Start is called before the first frame update
    void Start()
    {

    }

    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dark"))
        {
            Transform lastPosition = transform;
            Color fadeColor = Color.black;
            fadeColor.a = 1;
            fade.color = fadeColor;

            gameObject.transform.position = lastPosition.position;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dark"))
        {
            Color fadeColor = Color.black;
            fadeColor.a = 0;
            fade.color = fadeColor;

        }
    }






}

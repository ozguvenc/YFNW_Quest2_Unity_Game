using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class onTriggerAnimator : MonoBehaviour
{
    public Animator objectAnimator;
    public GameObject objectToAnimate;
    public GameObject playerMessage;
    public bool isInStation = false;
    public string useKey = "E";
    public int stationNumber = 0;
    public string[] messageTexts;
    private string stationMessage;
    public string messageText;

    public MeshRenderer objectMeshRenderer;


    private void Start()
    {
        messageTexts = new string[]
        {
            "check in at Your Friendly Neighborhood Witchshop.",
            "see your next pet. You shall have it in a fort night I bet!",
            "stir the potion, or it may spoil!",
            "wake up a doll that will avenge you without a brawl!",
            "command this broom. And watch it hover above this room!"
        };
        stationMessage = "Press " + useKey + " to "+ messageTexts[stationNumber];
    
        objectAnimator = objectToAnimate.GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInStation == true)
        {
            Debug.Log("E Key Pressed");
            objectAnimator.SetBool("playerClose", true);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player") && objectAnimator.GetBool("playerClose") == false)
        {
            playerMessage.GetComponent<TextMeshProUGUI>().text = stationMessage;
            Debug.Log("Player entered");

            isInStation = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMessage.GetComponent<TextMeshProUGUI>().text = "";
            isInStation = false;
            objectAnimator.SetBool("playerClose", false);
            Debug.Log("Player exited");
        }
    }
}

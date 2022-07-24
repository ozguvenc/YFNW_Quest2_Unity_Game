using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class deactivateOnTrigger : MonoBehaviour
{

    public GameObject teleportationWandPlaceholder;
    public GameObject teleportationWandOriginal;
    public GameObject leftHandController;
    public AudioSource audioSource;
    public AudioClip pickUpSound;
    public GameObject gameManager;
    public GameObject dialogManager;


    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {

    }




    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "LeftHand Controller" && gameManager.GetComponent<GameManager>().dialogNumber == 10)
        {
            audioSource.PlayOneShot(pickUpSound);
            teleportationWandOriginal.SetActive(true);
            teleportationWandPlaceholder.SetActive(false);
            gameManager.GetComponent<GameManager>().ChangeDialogNumber2(11);
            dialogManager.GetComponent<DialogManager>().StartPlayDialog2();
        }
    }



}

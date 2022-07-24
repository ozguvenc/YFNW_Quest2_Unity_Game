using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject audioManager;
    public GameObject ferah;
    public DialogManager ferahDialog;

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            if (gameObject.name == "Yes")
            {
                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, true, true, false, false, true, false, false, false, true);
                audioManager.GetComponent<AudioManager>().audioSource.PlayOneShot(audioManager.GetComponent<AudioManager>().uiSound);
                gameManager.GetComponent<GameManager>().dialogNumber = 12;
                ferahDialog.introDialogOver = true;
                ferahDialog.xrInteractionManager.SetActive(true);
                ferahDialog.StartCoroutine(ferahDialog.PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));
            }
            else if (gameObject.name == "No")
            {
                gameManager.GetComponent<GameManager>().UpdateSettings(false, false, false, false, false, false, false, false, true, true, true);
                audioManager.GetComponent<AudioManager>().audioSource.PlayOneShot(audioManager.GetComponent<AudioManager>().uiSound);
                gameManager.GetComponent<GameManager>().dialogNumber = 2;

                ferahDialog.StartCoroutine(ferahDialog.PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));
            }
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public GameManager gameManager;
    public DialogManager dialogManager;
    public GameObject nestor;
    public AudioClip nestorClip1;
    public AudioClip nestorClip2;
    public DialogManager ferahDialog;
    public bool nestorDialogOver;

    // Start is called before the first frame update
    void Start()
    {
        nestorDialogOver = false;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && nestorDialogOver == false)
        {
            StartCoroutine(NestorDialog());
        }
    }

    IEnumerator NestorDialog()
    {
        //dialogManager.xrInteractionManager.SetActive(false);
        ferahDialog.xrInteractionManager.SetActive(false);
        gameManager.leftHandController.SetActive(false);
        gameManager.rightHandController.SetActive(false);
        nestor.GetComponent<AudioSource>().clip = nestorClip1;
        nestor.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(nestor.GetComponent<AudioSource>().clip.length);

        //dialogManager.xrInteractionManager.SetActive(true);
        nestorDialogOver = true;
        gameManager.leftHandController.SetActive(true);
        gameManager.rightHandController.SetActive(true);
        ferahDialog.xrInteractionManager.SetActive(true);
    }
}

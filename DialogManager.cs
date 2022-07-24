using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameManager;
    public GameObject player;

    public List<AudioClip> dialogAudio = new List<AudioClip>();
    public List<string> dialogAnimation = new List<string>();
    public List<bool> autoTransition = new List<bool>();
    public List<float> waitBeforeDialog = new List<float>();
    public List<float> waitAfterDialog = new List<float>();
    public List<bool> updateGameSettings = new List<bool>();
    public AudioClip npcBarkFerah;
    public bool introDialogOver;
    public bool playerIsClose;
    public float minPlayerDistance;
    public bool barkIsRunning;
    public float minBarkTime;
    public float maxBarkTime;
    public GameObject xrInteractionManager;
    public bool xrInteractionOn;

    void Start()
    {
        if (!xrInteractionOn)
        {
            xrInteractionManager.SetActive(false);
        }
        


        StartCoroutine(PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));
        introDialogOver = false;
        barkIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - player.transform.position).magnitude < minPlayerDistance)
        {
            PlayBark();
        }

    }

    public IEnumerator PlayDialog(int dNumber)
    {

        if(dialogAudio[dNumber] == null)  
        {

            yield return null;

        }

        // Wait before the dialog begins..
        yield return new WaitForSeconds(waitBeforeDialog[gameManager.GetComponent<GameManager>().dialogNumber]);

        gameObject.GetComponent<AudioSource>().clip = dialogAudio[dNumber];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().SetTrigger(dialogAnimation[dNumber]);

        // Wait until the audio clip is done playing.
        yield return new WaitForSeconds(dialogAudio[dNumber].length);

        //<Animator>().SetTrigger("Idle");


        // Wait for waitAfterDialog seconds before the next dialog.
        yield return new WaitForSeconds(waitAfterDialog[dNumber]);

        if (updateGameSettings[dNumber])
        {
            DialogEvent();
        }

            if (autoTransition[dNumber])
        {
            gameManager.GetComponent<GameManager>().dialogNumber++;
            StartCoroutine(PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));
        }



    }
    public void DialogEvent()
    {
        switch(gameManager.GetComponent<GameManager>().dialogNumber)
        {
            case 1:

                gameManager.GetComponent<GameManager>().yesButton.SetActive(true);
                gameManager.GetComponent<GameManager>().noButton.SetActive(true);
                break;
            case 2:

                StartCoroutine(DelayedActivate(gameManager.GetComponent<GameManager>().playerNotification,7));
                break;
            case 5://Enable hands

                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, false, false, false, false, false, false, true, false, true);
                
                break;
            case 6: //Enable right hand grab

                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, false, true, false, false, false, false, true, false, true);
                break;
            case 10: //Enable wand pick up

                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, false, true, false, false, false, false, true, false, true);
                gameManager.GetComponent<GameManager>().teleportationWandPlaceHolder.GetComponent<deactivateOnTrigger>().enabled = true;
                gameManager.GetComponent<GameManager>().teleportationWandPlaceHolder.GetComponent<CapsuleCollider>().enabled = true;
                break;
            case 11: //Enable teleportation

                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, true, true, false, false, true, false, false, false, true);
                introDialogOver = true;
                break;
            case 12:

                gameManager.GetComponent<GameManager>().UpdateSettings(true, true, true, true, false, false, true, false, false, false, true);
                introDialogOver = true;
                break;
            case 13:
                Debug.Log("Case" + gameManager.GetComponent<GameManager>().dialogNumber);
                break;
            case 14:
                Debug.Log("Case" + gameManager.GetComponent<GameManager>().dialogNumber);
                break;
            default:
                Debug.Log("No valid dialog number is found.");
                break;

        }
    }



    IEnumerator DelayedActivate(GameObject objectToActivate, float time)
    {
        yield return new WaitForSeconds(time);
        objectToActivate.SetActive(true);
        xrInteractionManager.SetActive(true);

    }

    public void StartPlayDialog()
    {
        if (gameManager.GetComponent<GameManager>().ballHoldCounter < 3 && introDialogOver == false)
        {
            StartCoroutine(PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));
        }
    }

    public void StartPlayDialog2()
    {
        // Created for teleportation wand placeholder which somehow did not work with the original function. Checked all conditions.
            StartCoroutine(PlayDialog(gameManager.GetComponent<GameManager>().dialogNumber));

    }


    IEnumerator NpcBark(float minSec, float maxSec)
    {
        float sec = Random.Range(minSec, maxSec);

        yield return new WaitForSeconds(sec);

        gameObject.GetComponent<AudioSource>().clip = npcBarkFerah;
        gameObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
        barkIsRunning = false;

    }

    public void PlayBark()
    {
        if (introDialogOver == true && barkIsRunning == false && gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            StartCoroutine(NpcBark(minBarkTime, maxBarkTime));
            barkIsRunning = true;
        }
    }
}

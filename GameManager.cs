using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    [Header("General Settings")]
    public AudioSource audioSource;

    [Header("Player Settings")]
    public GameObject player;
    public GameObject mainCamera;
    public GameObject playerStartPosition;

    [Tooltip("Choose whether or not the player should spawn in the level starting position")]
    public bool spawnPlayerAtStart;

    [Header("Control Settings")]
    public GameObject leftHandController;
    public GameObject rightHandController;

    public GameObject leftHandModel;
    public GameObject rightHandModel;

    public GameObject teleportationWand;

    public bool leftHandVisible;
    public bool rightHandVisible;
    public bool leftHandFunctional;
    public bool rightHandFunctional;
    public bool teleportOn;

    [Header("Prop Settings")]
    public GameObject teleportationWandPlaceHolder;
    public GameObject handPlaceHolders;
    public GameObject theBall;

    public bool teleportationWandPlaceHolderActive;
    public bool handPlaceHoldersActive;
    public bool theBallActive;

    [Header("UI Settings")]
    public GameObject vrCanvas;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject playerNotification;
    public bool yesButtonActive;
    public bool noButtonActive;
    public bool playerNotificationActive;

    [Header("Dialog Settings")]
    public DialogManager dialogManager;
    public int dialogNumber;

    // Misc  variables.
    public int ballHoldCounter;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSettings(leftHandVisible, rightHandVisible, leftHandFunctional, rightHandFunctional, yesButtonActive, noButtonActive, teleportOn, spawnPlayerAtStart, teleportationWandPlaceHolderActive, handPlaceHoldersActive, theBallActive);
        ballHoldCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSettings(bool lHModel, bool rHModel, bool lHFunc, bool rHFunc, bool yBAct, bool nBAct, bool tOn, bool sPlayer, bool wandOn, bool handsOn, bool ballOn)
    {

        leftHandModel.SetActive(lHModel);
        rightHandModel.SetActive(rHModel);
        leftHandController.GetComponent<XRRayInteractor>().enabled = lHFunc;
        rightHandController.GetComponent<XRDirectInteractor>().enabled = rHFunc;
        yesButton.SetActive(yBAct);
        noButton.SetActive(nBAct);
        teleportationWand.SetActive(tOn);
        teleportationWandPlaceHolder.SetActive(wandOn);
        handPlaceHolders.SetActive(handsOn);
        theBall.SetActive(ballOn);

        if (sPlayer)
        {
            player.transform.position = playerStartPosition.transform.position;
            player.transform.rotation = playerStartPosition.transform.rotation;
        }
    }


    public void ChangeDialogNumber(int dNumber)
    {
        if (ballHoldCounter < 2 && dialogManager.introDialogOver == false)
        {
            dialogNumber = dNumber;
        }
        ballHoldCounter++;
    }

    public void ChangeDialogNumber2(int dNumber)
    {
        dialogNumber = dNumber;
    }
}

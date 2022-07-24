using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Animator animatorReference;
    public string objectTag;                    // Current object tag.
    public bool isInteractable;                 // Can player interact with this object?
    public bool isCollectible;                  // Can player pick this object up or drop it?
    public bool isUsable;                       // Can player hold this object for a special interaction with another object?
    public string objectState;                  // What is the current state of this object?
    public float objectResetTime;               // How many seconds does it take before a moved object resets to its position?
    Vector3 originalPosition;
    Quaternion originalRotation;
    public GameObject[] useList;                // The list of the other objects this object can interact with
    public Vector3 holdPositionOffset;                // The position for hsow the object should be held by the player.
    public Quaternion holdRotationOffset;             // The position for how the object should be held by the player.
    public GameObject playerCamera;
    public GameObject equippedItem;

    private void Start()
    {
        equippedItem = null;
        Debug.Log(equippedItem);
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRotation = gameObject.transform.rotation;
        playerCamera = GameObject.FindWithTag("MainCamera");
        
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        equippedItem = playerCamera.GetComponent<InteractionSystem>().equippedItem;
        StartCoroutine(objectReset(objectResetTime));

        if((equippedItem == gameObject))
        {
            Debug.Log("Stopping objectReset coroutine");
            //StopCoroutine(objectReset(objectResetTime));
        }

    }

    IEnumerator objectReset(float resetTime)
    {
        if ((equippedItem != gameObject) && ((Mathf.Abs(transform.position.x - originalPosition.x) > 1) || (Mathf.Abs(transform.rotation.eulerAngles.x - originalRotation.eulerAngles.x) > 30 )))
        {
            Debug.Log("Starting reset in " + resetTime + "seconds");
            yield return new WaitForSeconds(resetTime);
            gameObject.transform.position = originalPosition;
            gameObject.transform.rotation = originalRotation;
            Debug.Log("Object reset complete.");
        }
    }
}

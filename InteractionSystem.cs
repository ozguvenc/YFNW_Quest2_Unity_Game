using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    public GameObject currentTarget;                // The current target the raycast system is hitting.
    public GameObject lastInteractableTarget;       // The target that was hit before the current target.
    public GameObject pickupSlot;                   // The slot that will contain the held item.
    public GameObject equippedItem;                 // Store the item that the character is currently carrying.
    public Animator targetAnimator;                 // The animator component of the currently hit object.
    public float interactionDistance = 2f;          // The distance between the current target and the camera.
    public string[] messageTexts;                   // A list containing the list of messages the player may see.
    public KeyCode interactKey;                     // The input the player uses to interact with interactable objects.
    public KeyCode pickupDropKey;                   // The input the player uses to pick up or drop objects.
    public GameObject playerMessage;                // The UI element that shows the notifications to the player.
    public GameObject itemMessage;
    RaycastHit hit;                                 // Hit variable to store our results every frame.
    Vector3 raycastDirection;                       // A vector that shows the forward direction the camera is facing.

    private void Start()
    {                           
        equippedItem = null;                        // Player is not holding anything at start.
        lastInteractableTarget = null;              // Set the last target to become null.

        // Set up the text messages that can be shown to the player.
        messageTexts = new string[]
        {
            "interact", "take"
        };

        // Initialize the key layout
        interactKey = KeyCode.Mouse0;
        pickupDropKey = KeyCode.E; 
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.

    private void FixedUpdate()
    {
        // If carrying an item check if it can be dropped
       StartCoroutine(Drop(equippedItem, pickupDropKey, 0f));

        // Update the forward direction of the player every fixed frame.
        raycastDirection = transform.TransformDirection(Vector3.forward);

        // Conduct the raycast every fixed frame.
        if (Physics.Raycast(transform.position, raycastDirection, out hit))
        {
            // If there is a hit, draw a yellow line in scene view from camera to the hit object collider.
            Debug.DrawRay(transform.position, raycastDirection * hit.distance, Color.yellow);

            // Store the hit object in the currentTarget.
            currentTarget = hit.collider.gameObject;

            // Check if the object is within reach
            if (hit.distance <= interactionDistance) 
            {
                // Check to see if the object is interactable and curently not animating
                if (((currentTarget.tag == "Interactable") && AnimatorCheck("Idle")))
                {
                    // Store the current target to be used when target changes
                    lastInteractableTarget = currentTarget;

                    Highlight(currentTarget, true);

                    // Show the player notification
                    playerMessage.GetComponent<TextMeshProUGUI>().text = "Press " + interactKey.ToString() + " to " + messageTexts[0] + " with " + currentTarget.transform.name + ".";

                    Interact(currentTarget, interactKey);
                }
                else if ((currentTarget.tag == "Collectible") && (equippedItem == null))
                {
                    // Store the current target to be used when target changes
                    lastInteractableTarget = currentTarget;

                    // Show the player notification
                    playerMessage.GetComponent<TextMeshProUGUI>().text = "Press " + pickupDropKey.ToString() + " to " + messageTexts[1] + " the " + currentTarget.transform.name + ".";

                    Highlight(currentTarget, true);

                    StartCoroutine(Pickup(currentTarget, pickupDropKey, 0));
                }
            }
            // When target changes, turn off the object outline, ray gizmo color and length, and turn off player message.
            else
            {
                if (lastInteractableTarget != null)
                {
                    Highlight(lastInteractableTarget, false);
                }
                Debug.DrawRay(transform.position, raycastDirection * 1000, Color.white);
                playerMessage.GetComponent<TextMeshProUGUI>().text = "";
            }
        }

    }
    
    // *************************METHODS************************************** //

    // Add an outline highlight on the targeted object.
    private void Highlight(GameObject target, bool isOutlined)
    {
        target.GetComponent<Outline>().enabled = isOutlined;
    }

    private bool AnimatorCheck(string animatorState)
    {
        return ((currentTarget.GetComponent<Interactable>().animatorReference.GetCurrentAnimatorStateInfo(0).IsName(animatorState)));
    }

    // Activates the animator of the targeted object on input.
    private void Interact(GameObject target, KeyCode key)
    {
         // Check if mouse is pressed, then change animator parameter "playerClose" to true, else false.
                if (Input.GetKeyDown(key))
                {
                    target.GetComponent<Interactable>().animatorReference.SetBool("playerClose", true);
                }
                else
                {
                    target.GetComponent<Interactable>().animatorReference.SetBool("playerClose", false);
                }
    }

    IEnumerator Pickup(GameObject target, KeyCode key, float seconds)
    {
        if (Input.GetKeyDown(key))
        {
            if (equippedItem == null)
            {
                // Make the object child of the 
                yield return new WaitForSeconds(seconds);
                target.layer = LayerMask.NameToLayer("Equipped");
                Destroy(target.GetComponent<Rigidbody>());
                target.transform.parent = pickupSlot.transform;
                target.transform.localPosition = target.GetComponent<Interactable>().holdPositionOffset;
                target.transform.localRotation = target.GetComponent<Interactable>().holdRotationOffset;
                equippedItem = target;
                itemMessage.GetComponent<TextMeshProUGUI>().text = "Equipped: " + equippedItem.name;

            }
        }
    }

    // Drop the gameobject when a certain key is pressed and waits for a certain time before changing equipped state to avoid overlapped pickup/drop.
    IEnumerator Drop(GameObject target, KeyCode key, float seconds)
    {
        if (Input.GetKeyDown(key))
        {
            if (equippedItem != null)
            {
                // Drop what the player is holding.
                target.transform.parent = null;
                target.AddComponent<Rigidbody>();
                yield return new WaitForSeconds(seconds);
                target.layer = LayerMask.NameToLayer("Default");
                equippedItem = null;
                itemMessage.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    IEnumerator pause()
    {
        // Add a pause
            yield return new WaitForSeconds(3);
    }
    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float forceMagnitude;
    public GameObject target;
    public bool forceAdded;
    public AudioSource audioSource;
    public AudioClip otherHitSound;
    public AudioClip playerHitSound; 
    private bool collisionHappened;

    public GameObject attacker;
    public GameObject rightController;
    public GameObject leftController;
    public Image redImage;
    public GameObject player;
    public GameObject startPosition;
    public bool attackerDisabled;
    public float selfDestructDuration;
    public GameObject gameManager;
    public GameObject dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        redImage = GameObject.FindGameObjectWithTag("Fade").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = GameObject.FindGameObjectWithTag("Start Position");
        leftController = GameObject.FindGameObjectWithTag("Left Controller");
        rightController = GameObject.FindGameObjectWithTag("Right Controller");
        attacker = GameObject.FindGameObjectWithTag("Ludmila");

        gameManager = GameObject.FindGameObjectWithTag("GameController");
        dialogManager = GameObject.FindGameObjectWithTag("Dialog Manager");

        collisionHappened = false;
        audioSource = GetComponent<AudioSource>();
        forceAdded = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Target");
        transform.LookAt(target.transform.position, transform.up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!forceAdded)
        {
            //transform.LookAt(target.transform.position, transform.up);
            forceAdded = true;
            rb.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionHappened)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log(collision.gameObject.name);

            if (collision.gameObject.tag == "MainCamera")
            {
                audioSource.PlayOneShot(playerHitSound);
                Debug.Log("Player hit");
                StartCoroutine(DeathSequence(1, 0.01f));
                attacker.gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }
            else
            {
                audioSource.PlayOneShot(otherHitSound);
                Debug.Log("Player missed");
                attacker.gameObject.GetComponent<Animator>().SetTrigger("Idle");
            }
            rb.velocity.Set(0, 0, 0);
            rb.angularVelocity.Set(0, 0, 0);
            rb.isKinematic = true;
            gameObject.transform.SetParent(collision.gameObject.transform, true);
            collisionHappened = true;
            StartCoroutine(DestroySelf(selfDestructDuration));

        }
    }
    IEnumerator DestroySelf(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

        yield return null;
    }


    IEnumerator DeathSequence(float sec, float step)
    {

        attackerDisabled = true;

        yield return new WaitForSeconds(0.5f);


        Time.timeScale = 0f;

        rightController.SetActive(false);
        leftController.SetActive(false);


        Color fadeColor = Color.red;

        for (float a = 0f; a <= 1; a += step)
        {
            fadeColor.a = a;
            redImage.color = fadeColor;
            yield return null;
        }

        player.transform.position = startPosition.transform.position;

        Time.timeScale = 1f;

        attackerDisabled = false;


        gameManager.GetComponent<GameManager>().dialogNumber = (14);
        dialogManager.GetComponent<DialogManager>().StartPlayDialog2();

        for (float a = 1; a >= 0; a -= step)
        {
            fadeColor.a = a;
            redImage.color = fadeColor;
            yield return null;
        }

        rightController.SetActive(true);
        leftController.SetActive(true);
        dialogManager.GetComponent<Animator>().SetTrigger("Idle");
    }

}

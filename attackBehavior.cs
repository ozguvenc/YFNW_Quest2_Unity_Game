using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;


public class attackBehavior : MonoBehaviour
{
    public GameObject attacker;
    public AudioClip attackerClip;
    public GameObject redFade;
    public Image redImage;
    public GameObject player;
    public GameObject startPosition;
    public bool attackerDisabled;
    public GameObject scorchWand;
    public GameObject blocker;
    public GameObject rightController;
    public GameObject leftController;
    public GameObject deathParticle;
    public GameObject deathParticlePosition;
    public DialogManager dialogManager;
    public GameManager gameManager;
    public GameObject ferah;


    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {

        attackerDisabled = false;

    }



    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && attacker != null && attackerClip != null && !gameObject.CompareTag("Enemy"))
        {

            int attackNumber = Random.Range(1, 5);
            string attackName = "Attack" + attackNumber;

            if (attackerDisabled == false && scorchWand.GetComponent<wandAttack>().deathSequeneStarted == false)
            {
                attacker.gameObject.GetComponent<Animator>().SetTrigger(attackName);
            }
        }
    }


    public void Attack()
    {
        {
            if (gameObject.CompareTag("Enemy"))
            {
                StartCoroutine(DeathSequence(1, 0.01f));
            }
        }
    }

    IEnumerator DeathSequence(float sec, float step)
    {

        attackerDisabled = true;

        attacker.gameObject.GetComponent<AudioSource>().PlayOneShot(attackerClip);

        yield return new WaitForSeconds(0.5f);


        Time.timeScale = 0f;

        rightController.SetActive(false);
        leftController.SetActive(false);


        attacker.gameObject.GetComponent<Animator>().SetTrigger("Idle");

        redFade.SetActive(true);
        Color fadeColor = Color.red;

        for (float a = 0f; a <= 1; a += step)
        {
            fadeColor.a = a;
            redImage.color = fadeColor;
            yield return null;
        }

        player.transform.position = startPosition.transform.position;

        Time.timeScale = 1f;

        gameManager.dialogNumber = (13);
        dialogManager.StartPlayDialog2();

        attackerDisabled = false;

        for (float a = 1; a >= 0; a -= step)
        {
            fadeColor.a = a;
            redImage.color = fadeColor;
            yield return null;
        }

        rightController.SetActive(true);
        leftController.SetActive(true);

        ferah.GetComponent<Animator>().SetTrigger("Idle");
        
    }
}

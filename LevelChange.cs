using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public GameObject handLeft, handRight;

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == handLeft || other.gameObject == handRight)
        {
            SceneManager.LoadScene(1);
        }
    }


}

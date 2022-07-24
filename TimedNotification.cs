using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableAfterTime(5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
        
}

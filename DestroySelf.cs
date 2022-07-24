using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroy(4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

        yield return null;
    }
}

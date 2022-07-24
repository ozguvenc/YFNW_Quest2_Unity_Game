using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSpawner : MonoBehaviour
{
    private bool startFade;
    public Image fadeImage;
    public bool respawnPlayer;
    public float fadeLength;
    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startFade = false;
        StartCoroutine(StartFade(fadeLength, fadeSpeed));
    }


    IEnumerator StartFade(float sec, float step)
    {
        Color fadeColor = Color.black;

        for (float a = 1; a >= 0; a -= step * Time.deltaTime)
        {
            fadeColor.a = a;
            fadeImage.color = fadeColor;
            yield return null;
        }

    }

}

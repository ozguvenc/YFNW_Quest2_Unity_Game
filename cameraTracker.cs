using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracker : MonoBehaviour
{

    public GameObject mainCamera;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public Vector3 positionOffset;
    private float yEuler;
    public float yMin = 0f; 
    public float yMax = 30f;

    private void Update()
    {
        // yEuler = Mathf.Clamp(mainCamera.transform.localEulerAngles.y, yMin, yMax);

        yEuler = mainCamera.transform.localEulerAngles.y;

        transform.position = Camera.main.transform.position + positionOffset;
        gameObject.transform.eulerAngles = new Vector3(xOffset, yEuler + yOffset,
    zOffset
);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 lastCameraPosition;
    [SerializeField] private Vector2 parallaxAmount;
    [Range(0, 20)]
    [SerializeField] private float speed = 10;
    void Start()
    {
        cameraTransform = Camera.main.transform; //Transform of the camera
        lastCameraPosition = cameraTransform.position; //Last position of the camera
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; //Change in camera position
        //Move object by change in camera position * amount of parallax
        transform.position += new Vector3(deltaMovement.x * parallaxAmount.x, deltaMovement.y * parallaxAmount.y, 0);
        lastCameraPosition = cameraTransform.position; //Update last camera position
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 lastCameraPosition;
    [SerializeField] private Vector2 parallaxAmount;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxAmount.x, deltaMovement.y * parallaxAmount.y, deltaMovement.z);
        lastCameraPosition = cameraTransform.position;
    }
}

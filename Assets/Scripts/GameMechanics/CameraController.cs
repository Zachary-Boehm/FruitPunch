using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 cameraOffset;
    [SerializeField] private Transform PlayerTransform;
    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x + cameraOffset.x, cameraOffset.y, -25);
    }
}

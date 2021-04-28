using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 cameraOffset;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform[] clampTransforms;
    [SerializeField] private Vector3 currentClamper;
    private Vector3 destination;

    [Range(0f, 15f)]
    [SerializeField] private float speed;
    private int currentClamp = 0;
    private float fraction = 0;
    private void Start() {
        currentClamper = transform.position;
    }
    void FixedUpdate()
    {
        float x = Mathf.Clamp(PlayerTransform.position.x + cameraOffset.x, clampTransforms[currentClamp].position.x, clampTransforms[currentClamp + 1].position.x);
        destination = new Vector3(x, cameraOffset.y, -25);
        if (currentClamper != destination)
        {
            fraction = 0;
            currentClamper = transform.position;
        }
        if (fraction < 1)
        {
            fraction += Time.fixedDeltaTime * speed;
            transform.position = Vector3.Lerp(currentClamper, destination, fraction);
        }
    }

    public void incrementClamp()
    {
        currentClamp += 2;
        Debug.Log(currentClamp);
    }
}

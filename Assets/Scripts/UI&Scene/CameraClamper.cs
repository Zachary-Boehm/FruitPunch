using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraClamper : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Image Arrow;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            mainCamera.GetComponent<CameraController>().incrementClamp();
            GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.GetComponent<SectionController>().enabled = false;
            //Turn off the arrow showing the next section
            if(Arrow.enabled)
            {
                Arrow.enabled = false;
            }
        }
    }
}

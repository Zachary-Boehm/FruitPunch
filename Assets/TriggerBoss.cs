using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    
    [SerializeField] private BossMovement bossMovementScript;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            bossMovementScript.enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

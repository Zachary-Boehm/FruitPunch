using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.tag == "Player"){
        Debug.Log("Damage Player");
        other.gameObject.GetComponent<Health>().Damage(null,1f);
      }
    }
      
    
}

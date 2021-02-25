using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Attack : MonoBehaviour
{
    private void Start() {
      GetComponent<BoxCollider2D>().isTrigger = true;
      Rigidbody2D rb = GetComponent<Rigidbody2D>();
      rb.freezeRotation = true;
      rb.gravityScale = 0;
    }

    [SerializeField]private Weapon Weapon;//The gameobject weapon of this object. It will hold the damage Script
    //This method check for a collision with a collider and will check for a valid object to damage
    private void OnTriggerEnter2D(Collider2D Target) {
      //Check to see if object is a valid target.
      if(Target.tag == "Player" || Target.tag == "Enemy" && Target.isTrigger == true){
        DealDamage(Target.gameObject);
      }
    }

    //This method will apply the damage from the damage script to the target object
    public void DealDamage(GameObject target){
      if(target.GetComponent<Health>() && Weapon){
        //Call the Damage method on the Health script attached to target and pass values from damage script on this object
        target.GetComponent<Health>().Damage(Weapon.getDamageAmount(), Weapon.getDamageType());
      }else{
        //Debug statement to say that there is something missing for the logic to work
        Debug.Log("Target is missing the \"Health\" Script or the \"" + this.name + "\" object is missing a \"Weapon\" ScriptableObject");
      }
      
    }
}

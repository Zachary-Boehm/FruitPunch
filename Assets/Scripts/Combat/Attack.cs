using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Attack : MonoBehaviour
{
    private bool canAttack = false;
    private ActorVariables Variables;
    [SerializeField]private LayerMask TargetLayer;
    private void Start() {
      Rigidbody2D rb = GetComponent<Rigidbody2D>();
      Variables = GetComponent<ActorVariables>();
      rb.freezeRotation = true;
      rb.gravityScale = 0;
    }

    [SerializeField]private Weapon Weapon;//The gameobject weapon of this object. It will hold the damage Script
    private float Multiplier = 1;
    //this method when called will begin an attack
    public void AttackTarget(float multiplier = 1){
      Multiplier = multiplier;
      StartCoroutine(AttackTimer(Weapon.getAttackDuration())); //Begin the attack timer
      canAttack = true; //Allow the attack to begin
    }
    private void Update() 
    {
      if(canAttack)
      {
        //!Get the direction of the player's movement, then apply that to the direction of attack
        //Do a ray cast and store the collisions in the hit variable
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Variables.AttackDirection), Weapon.getAttackRange(), TargetLayer);
        //if hit is not null
        if(hit)
        {
          DealDamage(hit.collider.gameObject);//Deal damage to the hit target
          canAttack = false;//The attack is now finished
        }
      }
    }

    //This method will apply the damage from the damage script to the target object
    public void DealDamage(GameObject target)
    {
      if(target.GetComponent<Health>() && Weapon)
      {
        //Call the Damage method on the Health script attached to target and pass values from damage script on this object
        target.GetComponent<Health>().Damage(Weapon, Weapon.getDamageAmount() * Multiplier);
      }else{
        //Debug statement to say that there is something missing for the logic to work
        Debug.Log("Target is missing the \"Health\" Script or the \"" + this.name + "\" object is missing a \"Weapon\" ScriptableObject");
      }
    }

    //This coroutine is a timer for the attacks
    //If the timer is done before the attack hits something the attack will finish
    IEnumerator AttackTimer(float duration)
    {
      yield return new WaitForSeconds(duration); //wait for duration of attack
      canAttack = false; //Make it so attacks are not active
    }
}

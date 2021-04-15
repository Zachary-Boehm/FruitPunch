using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtack : MonoBehaviour
{
    private bool canAttack = false; //Determines if the object can attack
    private ActorVariables Variables;//Global variables for this object
    [SerializeField] private LayerMask TargetLayer;//The layer that will interact with the physics ray cast
    [Header("Weapon Details")]
    [SerializeField] private WeaponType weaponType; //The weapon type that is to be used for this object
    [SerializeField] private Weapon Weapon;//The gameobject weapon of this object. It will hold the damage Script
    private float Multiplier = 1;//Damage multiplier
    private void Start()
    {
        //Grab the weapon information from the Game Manager
        Weapon = GameManager.GAMEMANAGER.getWeapons().weapons[(int)weaponType];
        Rigidbody2D rb = GetComponent<Rigidbody2D>();//Reference to the objects rigid body
        Variables = GetComponent<ActorVariables>(); //Reference to the objects global variables
        rb.freezeRotation = true; //freeze the rotation of rigid body
        rb.gravityScale = 0; //Set the gravity for the rigid body to zero
    }

    //this method when called will begin an attack
    public void AttackTarget(float multiplier = 1)
    {
        Multiplier = multiplier; //Set the multiplier to what is passed or to the default of 1
        StartCoroutine(AttackTimer(Weapon.getAttackDuration())); //Begin the attack timer
        canAttack = true; //Allow the attack to begin
    }

    // Update is called once per frame
    void Update()
    { 
        if (canAttack)
        {
            Debug.Log("Can attack");
            //!Get the direction of the player's movement, then apply that to the direction of attack
            //Do a ray cast and store the collisions in the hit variable
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Variables.AttackDirection), Weapon.getAttackRange(), TargetLayer);
            //if hit is not null
            if (hit)
            {
                Debug.Log("Hit");
                DealDamage(hit.collider.gameObject);//Deal damage to the hit target
                canAttack = false;//The attack is now finished
            }
        }
    }

    //This method will apply the damage from the damage script to the target object
    public void DealDamage(GameObject target)
    {
        if (target.GetComponent<Health>() && Weapon != null)
        {
            //Call the Damage method on the Health script attached to target and pass values from damage script on this object
            target.GetComponent<Health>().Damage(Weapon, Weapon.getDamageAmount() * Multiplier);
        }
        else
        {
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

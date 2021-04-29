using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires there to be a rigid body for it to work
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ActorVariables))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private Vector2 Velocity; //Velocity based on input

    [Header("Player Constants")]
    [SerializeField] private ActorVariables Variables;
    [SerializeField] private Transform Transform; //Reference to the players transform
    [SerializeField] private Rigidbody2D PlayerRigidBody;//Reference to the Rigid body of the player
    [SerializeField] private Vector2 direction;//direction the player is moving in

    //Attack variables
    [Header("Attack Variables")]
    private bool AttackPressed = false;
    [SerializeField] private float chargeMultiplier;
    [SerializeField] private float chargeTime;
    private bool canAttack = true;
    private float chargeAmount = 0.0f;//percent of how much the player charged the attack
                                      //bool canMove = true;

    private void Awake()
    {
        Velocity = Vector2.zero; //Initialize the Velocity to (0,0)
        Transform = GetComponent<Transform>();//Initialize to transform of player
        PlayerRigidBody = GetComponent<Rigidbody2D>(); //Initialize to the rigidbody of the player
    }

    private void Update()
    {

        //Change sorting order based on y position
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        //inputs
        //Set the X of Velocity to the horizontal input * speed
        Velocity.x = Input.GetAxisRaw("Horizontal") * Variables.moveSpeed;
        //Set the Y of Velocity to the vertical input * speed
        Velocity.y = Input.GetAxisRaw("Vertical") * Variables.moveSpeed;

        if (GameManager.GAMEMANAGER.getCanMove() && !Variables.isAttacking)
        {
            //!Optimize Here
            direction = Velocity.normalized;
            Variables.Direction = direction;
            if (direction.x != 0)
            {
                Variables.AttackDirection = direction;
            }
        }
        else
        {
            direction = Vector2.zero;
        }


        //Check for attack button to be pressed
        if (Input.GetAxisRaw("Fire1") > 0.01 && !AttackPressed && canAttack)
        {
            AttackPressed = true;
            //Button pressed
            StartCoroutine(chargeAttack());//Start a coroutine that will charge a attack over time
        }
        else if (Input.GetAxisRaw("Fire1") == 0 && AttackPressed == true)
        {
            AttackPressed = false;
            //Button Released
            releaseAttack();
            StartCoroutine(AttackCooldown(0.5f));
        }
    }

    private void FixedUpdate()
    {
        //Apply motion
        //Set the velocity of the player's rigid body to the Velocity(input) * the change in time between frames
        if (!Variables.isAttacking && GameManager.GAMEMANAGER.getCanMove())
        {
            PlayerRigidBody.velocity = Velocity * Time.deltaTime;
        }
        else
        {
            PlayerRigidBody.velocity = Vector2.zero;
        }
    }

    IEnumerator chargeAttack()
    {
        Variables.isAttacking = true;
        GetComponent<AnimationController>().ChangeAnim(SceneConstants.PunchChargeAnim);
        while (chargeAmount < 100)
        {
            yield return new WaitForSeconds(chargeTime / 100);
            chargeAmount += 1f;
        }
    }
    private void releaseAttack()
    {
        StopAllCoroutines();//Stop charging the attack
        float mult = (chargeAmount / 100) * chargeMultiplier; //Damage mutliplier for charge attack
        if (mult < 1)
        {//Damage will at least be 1
            mult = 1;
        }
        GetComponent<AnimationController>().ChangeAnim(SceneConstants.PunchReleaseAnim);
        GetComponent<Attack>().AttackTarget(mult);//Send out the attack after the release
        chargeAmount = 0;//reset the charge
    }


    IEnumerator AttackCooldown(float duration)
    {
        canAttack = false;
        yield return new WaitForSeconds(duration); //wait for duration of attack
        canAttack = true;
    }
}

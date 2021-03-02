using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires there to be a rigid body for it to work
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
  [Header("Player Attributes")]
  [SerializeField] private Vector2 Velocity; //Velocity based on input
  [SerializeField] private Transform Transform; //Reference to the players transform
  [SerializeField]private Rigidbody2D PlayerRigidBody;//Reference to the Rigid body of the player
  [Header("Player Constants")]
  [SerializeField] private float Speed; //Speed at which the player will move
  
  private void Awake() {
    Velocity = Vector2.zero; //Initialize the Velocity to (0,0)
    Transform = GetComponent<Transform>();//Initialize to transform of player
    PlayerRigidBody = GetComponent<Rigidbody2D>(); //Initialize to the rigidbody of the player
  }

  private void Update() {
    //inputs
    //Set the X of Velocity to the horizontal input * speed
    Velocity.x = Input.GetAxisRaw("Horizontal") * Speed;
    //Set the Y of Velocity to the vertical input * speed
    Velocity.y = Input.GetAxisRaw("Vertical") * Speed;
  }

  private void FixedUpdate() {
    //Apply motion
    //Set the velocity of the player's rigid body to the Velocity(input) * the change in time between frames
    PlayerRigidBody.velocity = Velocity * Time.deltaTime;
  }
}

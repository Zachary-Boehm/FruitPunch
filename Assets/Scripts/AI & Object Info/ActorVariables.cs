using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [Header("Default Values")]
    [SerializeField]private float defaultSpeed; //default speed of object
    [SerializeField]private float defaultHealth;//default health of object
    [Header("Variables")]
    public float moveSpeed; //current movement speed of the object
    public float health; //current health of the object

    public Vector2 Direction; //direction the object is facing
    public Vector2 AttackDirection; //Direction the object is attacking
    public bool isAttacking; //Toggle for whether the object is attacking

    //Resets current speed to default speed
    public void ResetSpeed()
    {
      moveSpeed = defaultSpeed;
    }
    //sets current health to default health
    public void ResetHealth()
    {
      health = defaultHealth;
    }
    //Returns the default health of the object
    public float getDefaultHealth(){
      return defaultHealth;
    }
}

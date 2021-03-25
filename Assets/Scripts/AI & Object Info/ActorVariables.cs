using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [Header("Default Values")]
    [SerializeField]private float defaultSpeed;
    [SerializeField]private float defaultHealth;
    [Header("Variables")]
    public float moveSpeed;
    public float health;

    public Vector2 Direction;
    public Vector2 AttackDirection;
    public bool isAttacking;

    public void ResetSpeed()
    {
      moveSpeed = defaultSpeed;
    }
    public void ResetHealth()
    {
      health = defaultHealth;
    }
    public float getDefaultHealth(){
      return defaultHealth;
    }
}

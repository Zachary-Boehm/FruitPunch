using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Damage : MonoBehaviour
{
    //DamageType refers to the enum type to assign what type of damage the object will do.
    [SerializeField] DamageType DamageType;
    //The amount of damage this object will do
    [SerializeField] float damage;
}

public enum DamageType{
  Slow, //Will slow target
  Stun, //Will stun target
  Bleed, //Will apply bleed affect to the target
  Other //Default state
}


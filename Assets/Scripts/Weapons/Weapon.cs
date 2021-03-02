using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    //DamageType refers to the enum type to assign what type of damage the object will do.
    [SerializeField] private DamageAffect DamageAffect;
    //The amount of damage this object will do
    [SerializeField] private float damage;

    public int getDamageType(){
      return (int)DamageAffect;
    }
    public float getDamageAmount(){
      return damage;
    }
}

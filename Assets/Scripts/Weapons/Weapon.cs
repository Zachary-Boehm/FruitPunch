using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    //DamageType refers to the enum type to assign what type of damage the object will do.
    [SerializeField] private DamageAffect DamageAffect;
    
    //The duration in seconds that a damage affect will last
    [SerializeField] private float EffectDuration;
    //If the type is bleed then this is the amount of damage that will accure every "tic"
    [SerializeField] private float BleedAmount;
    //The amount of damage this object will do
    [SerializeField] private float damage;
    //The duration of the attack
    [SerializeField] private float attackDuration;
    //Attack Range
    [SerializeField] private int attackRange;
    public int getDamageType(){
      return (int)DamageAffect;
    }
    public float getDamageAmount(){
      return damage;
    }
    public float getDuration(){
      return EffectDuration;
    }
    public float getBleedAmount(){
      return BleedAmount;
    }

    public float getAttackDuration(){
      return attackDuration;
    }

    public int getAttackRange(){
      return attackRange;
    }
}

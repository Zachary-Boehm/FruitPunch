using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    //Name of the weapon
    [SerializeField]private string name = "";
    //DamageType refers to the enum type to assign what type of damage the object will do.
    [SerializeField]private int damageAffect = 0;
    
    //The duration in seconds that a damage affect will last
    [SerializeField]private float effectDuration = 0.0f;
    //If the type is bleed then this is the amount of damage that will accure every "tic"
    [SerializeField]private float bleedAmount = 0.0f;
    //The amount of damage this object will do
    [SerializeField]private float damage = 0.0f;
    //The duration of the attack
    [SerializeField]private float attackDuration = 0.0f;
    //Attack Range
    [SerializeField]private int attackRange = 0;
    public int getDamageType()
    {
        return (int)damageAffect;
    }
    public float getDamageAmount()
    {
        return damage;
    }
    public float getDuration()
    {
        return effectDuration;
    }
    public float getBleedAmount()
    {
        return bleedAmount;
    }

    public float getAttackDuration()
    {
        return attackDuration;
    }

    public int getAttackRange()
    {
        return attackRange;
    }
}
//This class holds a list of weapons that can be written and read from a json
[System.Serializable]
public class WeaponList
{
    public Weapon[] weapons;//List of weapon objects
}

//Weapon types that can be selected in editor
//IMPORTANT: Change the integer values if the order in the json changes
public enum WeaponType
{
    Fist = 0, //The fist weapon
    GrapeFist = 1 //The whip weapon
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Constants")]
    [SerializeField]private float health; //Current health of the object

    public bool Damage(float _damage, int _damageType){

      //Checks for valid input of Damage Type
      if(_damageType < 0 || _damageType > 2){
        return false;
      }

      //Find what the new health will be after the damage is taken
      float newHealth = health - _damage;
      //If Health is now below or at 0 kill player/enemy
      if(newHealth <= 0){
        //Set health to 0
        health = 0;
        //Do logic for death
        Destroy(this.gameObject);
      }else{ //Else if the health is above 0
        //Set the current health to the new health
        health = newHealth;
      }
      DamageAffect(_damageType);
      //Return true because the damage logic has passed.
      return true;
    }

    //This method will take in the damage type and apply it to the target object(this).
    private bool DamageAffect(int damageType)
    {
      switch(damageType){
        case 0:
        break;
        case 1:
        break;
        case 2:
        break;
        case 3:
        break;
        case 4:
        break;
        default:
        break;
      }
      //do logic to apply damage affect.
      return false; //Method is not implemented yet
    }

    //Variable that acts as a getter and setter for the health variable
    public float HealthAccessor{get{return health;} set{health = value;}}
    
}

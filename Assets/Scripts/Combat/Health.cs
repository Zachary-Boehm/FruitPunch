using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StaticVariables))]
public class Health : MonoBehaviour
{
    [Header("Constants")]
    [SerializeField]private float health; //Current health of the object

    [SerializeField]private StaticVariables Variables;
    private void Start() {
      health = GetComponent<StaticVariables>().health;//Set the health to the default health in the variables script
    }

    /*
      This method is called and will deal the damage that the weapon gives
      @param _weapon Weapon that is used by the enemy
    */
    public void Damage(Weapon _weapon, float _damage = -1){
      //Find what the new health will be after the damage is taken
      float newHealth;
      if(_damage == -1)
      {
        newHealth = health - _weapon.getDamageAmount();
      }else
      {
        newHealth = health - _damage;
      }
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
      
      //Checks for valid input of Damage Type
      if(_weapon != null){
        if(_weapon.getDamageType() > 0 || _weapon.getDamageType() < 4){
          Debug.Log("dealing affect");
          DamageAffect(_weapon);//call the logic for the effect since the type is vaild
        }
      }
    }

    /*
      This method will take in the damage type and apply it to the target object(this).
      @param _weapon Reference to the weapon being used against this object
    */
    private bool DamageAffect(Weapon _weapon)
    {
      //do logic to apply damage affect.

      switch(_weapon.getDamageType())
      {
        case 1:
          //slow - change moveSpeed in static variables to be slower via percentage
          StartCoroutine(Slow(_weapon.getDuration(), 0.5f));
        break;
        case 2:
          //stun - change moveSpeed in static variables to 0 for a set duration
          StartCoroutine(Stun(_weapon.getDuration()));
        break;
        case 3:
          //bleed (coroutine) - deal damage over time
          StartCoroutine(Bleed(_weapon.getDuration(), _weapon.getBleedAmount()));
        break;
        default:
          //Error message
          Debug.Log("Damage type does not exist!");
        break;
      }


      return false; //Method is not implemented yet
    }

    //Variable that acts as a getter and setter for the health variable
    public float HealthAccessor{get{return health;} set{health = value;}}

    //!Coroutines
    /*
      This coroutine will change the move speed to 0 for a set duration then set it back to default
      @param _duration Duration that he effect will be appied
    */
    IEnumerator Stun(float _duration)
    {
      Variables.moveSpeed = 0.0f; //Set the move speed to 0
      yield return new WaitForSeconds(_duration); //Wait for duration
      Variables.ResetSpeed(); //Set the move speed back to default
    }
    /*
      This coroutine will change the move speed to a percent of the default speed then change it back
      @param _duration Duration that he effect will be appied
      @param _slowAmount Percentage of which the object will be slowed down by
    */
    IEnumerator Slow(float _duration, float _slowAmount)
    {
      Variables.moveSpeed = Variables.moveSpeed * _slowAmount; //Decrease move speed by %
      yield return new WaitForSeconds(_duration); //Wait for duration
      Variables.ResetSpeed(); //Set the move speed back to default
    }
    /*
      This coroutine will apply a set amount of damage every 1/2 second for the length of the duration.
      @param _duration Duration that he effect will be appied
      @param _damageAmount Damage that will be applied every 1/2 seconds
    */
    IEnumerator Bleed(float _duration, float _damageAmount)
    {
      float ElapsedTime = 0; //Current time elapsed
      while(ElapsedTime < _duration)//Keep dealing damage until _duration is met
      {
        Damage(null, _damageAmount); //Damage the object 
        yield return new WaitForSeconds(0.5f);//Wait for 1/2 seconds
        ElapsedTime += 0.5f; //increase the elapsed time
      }
      
    }

}

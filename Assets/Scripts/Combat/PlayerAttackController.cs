using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private bool attackPressed = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0.01 && attackPressed == false){//Pressed the attack button
          GetComponent<Attack>().AttackTarget();
          attackPressed = true;
        }
        if(Input.GetAxisRaw("Fire1") == 0){//Button release/no longer inputting into this axis
          attackPressed = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [SerializeField]private float defaultSpeed;
    public float moveSpeed;
    public float health;

    public void ResetSpeed()
    {
      moveSpeed = defaultSpeed;
    }
}

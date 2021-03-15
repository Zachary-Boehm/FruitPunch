using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 30;
    int MaxDist = 10;
    int MinDist = 5;


    Vector3 movement = Vector3.zero;
    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
          movement = (Player.position - transform.position).normalized * MoveSpeed * Time.deltaTime;
          movement.z = 0;
        }
        else
        {
          movement = Vector3.zero;
        }
    }
    private void FixedUpdate() {
      transform.position += movement;
    }
}

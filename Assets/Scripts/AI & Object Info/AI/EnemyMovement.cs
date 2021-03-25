using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    //int MaxDist = 10;
    int MinDist = 10;
    private ActorVariables Variables;

    Vector3 movement = Vector3.zero;
    [SerializeField] private Vector2 Direction;
    void Start()
    {
      Variables = GetComponent<ActorVariables>();
    }

    void Update()
    {
        Direction = (Player.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, Player.position) >= MinDist && !GetComponent<ActorVariables>().isAttacking)
        {
          movement =  Direction * Variables.moveSpeed * Time.deltaTime;
          movement.z = 0;
        }
        else
        {
          Direction = Vector2.zero;
          movement = Vector3.zero;
        }
        
        GetComponent<ActorVariables>().Direction = Direction;
        if(Direction.x != 0){
          GetComponent<ActorVariables>().AttackDirection = Direction;
        }
    }
    private void FixedUpdate() {
      transform.position += movement;
    }
}

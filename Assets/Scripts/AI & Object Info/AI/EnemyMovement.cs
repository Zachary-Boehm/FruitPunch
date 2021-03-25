using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    //int MaxDist = 10;
    int MinDist = 10;
    private StaticVariables Variables;

    Vector3 movement = Vector3.zero;
    [SerializeField] private Vector2 Direction;
    void Start()
    {
      Variables = GetComponent<StaticVariables>();
    }

    void Update()
    {
        Direction = (Player.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, Player.position) >= MinDist && !GetComponent<StaticVariables>().isAttacking)
        {
          movement =  Direction * Variables.moveSpeed * Time.deltaTime;
          movement.z = 0;
        }
        else
        {
          Direction = Vector2.zero;
          movement = Vector3.zero;
        }
        
        GetComponent<StaticVariables>().Direction = Direction;
        if(Direction.x != 0){
          GetComponent<StaticVariables>().AttackDirection = Direction;
        }
    }
    private void FixedUpdate() {
      transform.position += movement;
    }
}

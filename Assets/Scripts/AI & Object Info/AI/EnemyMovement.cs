using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    //int MaxDist = 10;
    int MinDist = 5;
    [SerializeField]private ActorVariables Variables;
    [SerializeField] private Attack Attack;
    bool isChasing = false;
    bool isAttacking = false;
    bool canAttack = false;
    Vector3 movement = Vector3.zero;
    [SerializeField] private Vector2 Direction;
    
    [SerializeField] private float cooldown;
    void Update()
    {
        float enemyDistance = Vector3.Distance(transform.position, Player.position);
        if (enemyDistance <= 30 && isChasing == false)
        {
            isChasing = true;
        }
        if (isChasing == true && GameManager.GAMEMANAGER.getCanMove())
        {
            
            if (enemyDistance >= MinDist && !GetComponent<ActorVariables>().isAttacking)
            {
                Direction = (Player.position - transform.position).normalized;
                movement = Direction * Variables.moveSpeed * Time.deltaTime;
                movement.z = 0;
            }
            else
            {
                Direction = Vector2.zero;
                movement = Vector3.zero;
                Attack aScript = GetComponent<Attack>();
                if (canAttack == false && aScript)
                {
                    if (aScript.enabled == true)
                    {
                        Debug.Log("attack player");
                        GetComponent<AnimationController>().ChangeAnim(SceneConstants.Punch);
                        StartCoroutine(attackCooldown());
                        canAttack = true;
                    }
                }
            }

            GetComponent<ActorVariables>().Direction = Direction;
            if (Direction.x != 0)
            {
                GetComponent<ActorVariables>().AttackDirection = Direction;
            }
        }
    }
    private void FixedUpdate() {
      transform.position += movement;
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = false;
        Debug.Log("Finished Attacking player");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MyBehaviourScript
{
    [Header("Starts")]
    public float speed = 2f;
    public float distance = 0.5f;
    public Transform Target;

    public override void Update()
    {
        base.Update();
        this.Move();
        this.SetTarget();
    }

    private void SetTarget()
    {
        EnemyAnimation.Instance.SetFloat("xPlayer", Target.position.x);
        EnemyAnimation.Instance.SetFloat("yPlayer", Target.position.y);
    }

    private void Move()
    {
        Vector2 directionToPlayer = (Target.position - transform.parent.position).normalized;

        if (Vector2.Distance(transform.parent.position, Target.position) > distance)
        {
            transform.parent.Translate(directionToPlayer * speed * Time.deltaTime);
            if(directionToPlayer!=Vector2.zero)
            {
                EnemyAnimation.Instance.SetBool("Move",true);
            }
        }
        else
        {
            EnemyAttack.Instance.Attack();
            if (directionToPlayer.x != 0 || directionToPlayer.y != 0)
            {
                EnemyAnimation.Instance.SetBool("Move", false);
            }
            else
            {
                
                if (directionToPlayer.x > directionToPlayer.y)
                {
                    directionToPlayer.y = 0;
                    transform.parent.Translate(directionToPlayer * speed * Time.deltaTime);
                }
                else
                {
                    directionToPlayer.x = 0;
                    transform.parent.Translate(directionToPlayer * Vector2.up * speed * Time.deltaTime);
                }
            }
        }


    }
}

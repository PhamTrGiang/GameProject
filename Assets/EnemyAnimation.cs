using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MyBehaviourScript
{
    private Animator anim;

    private bool isRight = true;
    public Transform Target;


    private static EnemyAnimation instance;
    public static EnemyAnimation Instance { get { return instance; } }

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void Awake()
    {
        base.Awake();
        if (instance != null && instance == this) return;
        instance = this;
    }

    public override void Update()
    {
        base.Update();
        this.SetAttackDirection();
        this.Flip();
    }

    private void SetAttackDirection()
    {
        Vector2 directionToPlayer = (Target.position - transform.parent.position);
        float x = directionToPlayer.x;
        float y = directionToPlayer.y;

        float valueDirection = 0;

        if (Math.Abs(x) > Math.Abs(y))
        {
            valueDirection = 0;
        }
        else
        {
            valueDirection = y>0 ? 1 : -1;
        }
        anim.SetFloat("AttackDirection", valueDirection);
    }

    public void SetTrigger(string action)
    {
        anim.SetTrigger(action);
    }
    public void SetBool(string action, bool status)
    {
        anim.SetBool(action, status);
    }
    public void SetFloat(string name,float value)
    {
        anim.SetFloat(name,value);
    }
    public float GetFloat(string name)
    {
        return anim.GetFloat(name);
    }

    private void Flip()
    {
        float x = this.transform.parent.position.x;
        float xPlayer = Target.position.x;
        if (isRight && x > xPlayer || !isRight && x < xPlayer)
        {
            isRight = !isRight;
            Vector3 flip = transform.parent.localScale;
            flip.x = flip.x * -1;
            transform.parent.localScale = flip;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerController
{
    [Header("starts")]
    public float attackSpeed = 1f;
    public float attackRange = 0.3f;
    public LayerMask enemyLayer;


    private Vector2 side, front, back;
    private float attackTimer = 0f;
    private float y = 0;

    public override void Start()
    {
        base.Start();
        side = new Vector2(0.5f, 0);
        front = new Vector2(0, -0.5f);
        back = new Vector2(0, 0.4f);
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    public override void Update()
    {
        base.Update();
        Attack();

        y = PlayerAnimation.Instance.GetFloat("y");
    }
    private void Attack()
    {
        if (attackTimer < attackSpeed) attackTimer += Time.deltaTime;
        if (attackTimer < attackSpeed) return;
        if (Input.GetButton("Fire1"))
        {
            PlayerController.Instance.SetAnimAttack();
            Invoke("HitDame", attackSpeed * 0.2f);
            attackTimer = 0;
        }
    }



    private void HitDame()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.AttackDirection(), attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("test hit :" + enemy.name);
        }
    }

    private Vector2 AttackDirection()
    {
        Vector2 attackDirection;

        if (y == 0)
        {
            attackDirection = (Vector2)transform.position + side * transform.parent.localScale;
        }
        else
        {
            if (y > 0)
            {
                attackDirection = (Vector2)transform.position + back;
            }
            else
            {
                attackDirection = (Vector2)transform.position + front;
            }
        }
        
        
        return attackDirection;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.AttackDirection(), attackRange);
    }
}

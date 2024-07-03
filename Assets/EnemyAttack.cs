using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MyBehaviourScript
{
    [Header("starts")]
    public float attackSpeed = 1f;
    public float attackRange = 0.3f;
    public LayerMask playerLayer;
    private Vector2 side, front, back;
    private float valueDirection = 0;


    [HideInInspector]
    public float attackTimer = 10f;


    private static EnemyAttack instance;
    public static EnemyAttack Instance { get { return instance; } }
    public override void Awake()
    {
        base.Awake();
        if (instance != null && instance == this) return;
        instance = this;
    }

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
        playerLayer = LayerMask.GetMask("Player");
    }

    public override void Update()
    {
        base.Update();
        valueDirection = EnemyAnimation.Instance.GetFloat("AttackDirection");
    }
    public void Attack()
    {
        if (attackTimer < attackSpeed) attackTimer += Time.deltaTime;
        if (attackTimer < attackSpeed) return;

        EnemyAnimation.Instance.SetTrigger("Attack");
        attackTimer = 0;

        Invoke("HitDame", attackSpeed * 0.2f);

    }

    private void HitDame()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.AttackDirection(), attackRange, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("test hit :" + enemy.name);
        }
    }
    
    private Vector2 AttackDirection()
    {
        Vector2 attackDirection;

        if (valueDirection == 0)
        {
            attackDirection = (Vector2)transform.position + side * transform.parent.localScale;
        }
        else
        {
            if (valueDirection > 0)
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


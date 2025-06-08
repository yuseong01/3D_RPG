using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    [Header("Enemy Stat")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int maxHP = 50;
    
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public int CurrentHP { get; private set; }

    [HideInInspector] public EnemyIdleState idleState;
    [HideInInspector] public EnemyChaseState chaseState;
    [HideInInspector] public EnemyAttackState attackState;

    public void Start()
    {
        CurrentHP = maxHP;
        
        idleState = new EnemyIdleState(this);
        //chaseState = new EnemyChaseState(this);
        //attackState = new EnemyAttackState(this);
        
        ChangeState(idleState);
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
}

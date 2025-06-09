using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    [Header("Enemy Stat")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int maxHP = 50;
    [SerializeField] private int currentHP;
    
    //읽기전용
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public int CurrentHP => currentHP; 

    [HideInInspector] public EnemyIdleState idleState;
    [HideInInspector] public EnemyChaseState chaseState;
    [HideInInspector] public EnemyAttackState attackState;

    public void Start()
    {
        currentHP = maxHP;
        
        idleState = new EnemyIdleState(this);
        //chaseState = new EnemyChaseState(this);
        //attackState = new EnemyAttackState(this);
        
        ChangeState(idleState);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("공격 받는중");
        currentHP -= damage;
        
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

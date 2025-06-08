using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    [Header("Enemy Stat")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 1.5f;
    
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;

    [HideInInspector] public EnemyIdleState idleState;
    //[HideInInspector] public EnemyChaseState chaseState;
    //[HideInInspector] public EnemyAttackState attackState;

    public void Start()
    {
        idleState = new EnemyIdleState(this);
        //chaseState = new EnemyChaseState(this);
        //attackState = new EnemyAttackState(this);
        
        ChangeState(idleState);
    }
}

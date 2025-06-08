using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    [Header("Player Stat")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackRange = 2f;
    
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public Transform CachedTransform { get; private set; }

    //[HideInInspector] public PlayerIdleState idleState;
    [HideInInspector] public PlayerMoveState moveState;
    //[HideInInspector] public PlayerAttackState attackState;

    private void Awake()
    {
        CachedTransform = transform;
    }
    public void Start()
    {
        //idleState = new PlayerIdleState(this);
        moveState = new PlayerMoveState(this);
        //attackState = new PlayerAttackState(this);

        ChangeState(moveState);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : StateMachine
{
    [Header("Player Stat")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float detectRange = 5f;
    private NavMeshAgent agent;
    
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public float DetectRange => detectRange;
    public NavMeshAgent Agent => agent;
    public Transform CachedTransform { get; private set; }

    
    //[HideInInspector] public PlayerIdleState idleState;
    [HideInInspector] public PlayerMoveState moveState;
    [HideInInspector] public PlayerAttackState attackState;

    private void Awake()
    {
        CachedTransform = transform;
    }
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        
        //idleState = new PlayerIdleState(this);
        moveState = new PlayerMoveState(this);
        attackState = new PlayerAttackState(this);
        
        ChangeState(moveState);
    }

}

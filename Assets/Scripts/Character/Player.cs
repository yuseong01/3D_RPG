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
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int maxHP = 50;
    [SerializeField] private int currentHP;
    
    private NavMeshAgent agent;
    
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public float DetectRange => detectRange;
    public int AttackDamage => attackDamage;
    public int CurrentHP => currentHP;
    
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
        currentHP = maxHP;
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        
        //idleState = new PlayerIdleState(this);
        moveState = new PlayerMoveState(this);
        attackState = new PlayerAttackState(this);
        
        ChangeState(moveState);
    }
    
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        
        if (CurrentHP <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("Player Dead");
        Destroy(gameObject);
        //게임오버
    }
    
    private void OnDrawGizmos()
    {
        // 감지 범위 (빨간색 원)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);

        // 공격 범위 (노란색 원)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : StateMachine
{
    [Header("Enemy Stat")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int maxHP = 50;
    [SerializeField] private int currentHP;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private int attackDamage = 5;
    
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    private NavMeshAgent agent;
    
    //읽기전용
    public float MoveSpeed => moveSpeed;
    public float AttackRange => attackRange;
    public int CurrentHP => currentHP;
    public float DetectionRange => detectionRange;
    public int AttackDamage => attackDamage;
    
    public Transform PlayerTransform => playerTransform;
    public NavMeshAgent Agent => agent;
    public IState CurrentState => currentState;

    [HideInInspector] public EnemyIdleState idleState;
    [HideInInspector] public EnemyChaseState chaseState;
    [HideInInspector] public EnemyAttackState attackState;

    public void Start()
    {
        currentHP = maxHP;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        
        idleState = new EnemyIdleState(this);
        chaseState = new EnemyChaseState(this);
        attackState = new EnemyAttackState(this);

        ChangeState(idleState);
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
        GameManager.Instance.Gold += 10;
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
    
    private void OnDrawGizmos()
    {
        // 감지 범위 (빨간색 원)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // 공격 범위 (노란색 원)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

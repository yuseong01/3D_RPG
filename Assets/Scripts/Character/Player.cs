using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class PlayerStat
{
    [Header("Player Stat")]
    [SerializeField] private int maxHP = 50;
    [SerializeField] private int currentHP;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private int attackRange = 2;
    [SerializeField] private int detectRange = 5;
    
    public int MaxHP => maxHP;
    public int CurrentHP { get => currentHP; set => currentHP = value; }
    public int AttackDamage => attackDamage;
    public int MoveSpeed => moveSpeed;
    public int AttackRange => attackRange;
    public int DetectRange => detectRange;
}
public class Player : StateMachine
{
    [SerializeField] PlayerStat playerStat;

    private NavMeshAgent agent;
    
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
        playerStat.CurrentHP = playerStat.MaxHP;
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = playerStat.MoveSpeed;
        
        moveState = new PlayerMoveState(this, playerStat);
        attackState = new PlayerAttackState(this, playerStat);
        
        ChangeState(moveState);
    }
    
    public void TakeDamage(int damage)
    {
        playerStat.CurrentHP -= damage;
        
        if (playerStat.CurrentHP <= 0)
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
        Gizmos.DrawWireSphere(transform.position, playerStat.DetectRange);

        // 공격 범위 (노란색 원)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerStat.AttackRange);
    }

}

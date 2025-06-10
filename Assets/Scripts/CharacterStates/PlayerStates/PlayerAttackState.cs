using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private Player player;
    private PlayerStat playerStat;
    private Transform playerTransform;
    private float attackRange;
    private int attackDamage;

    private float attackCooldown = 1f;
    private float lastAttackTime;

    private int enemyLayerMask;

    private Coroutine detectCoroutine;
    private WaitForSeconds waitForSeconds;
    
    Collider[] enemyColliders = new Collider[10];

    
    public PlayerAttackState(Player player, PlayerStat playerStat)
    {
        this.player = player;
        this.playerStat = playerStat;
        this.playerTransform = player.CachedTransform;
        this.attackRange = playerStat.AttackRange;
        this.attackDamage = playerStat.AttackDamage;
        
        waitForSeconds = new WaitForSeconds(0.2f); 

        enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    public void Enter()
    {
        Debug.Log("PlayerAttack State Enter");

        detectCoroutine = player.StartCoroutine(DetectEnemyCoroutine());
        
    }

    public void Tick()
    {
        
    }

    private IEnumerator DetectEnemyCoroutine()
    {
        while (true)
        {
            AttackDetectedEnemy();
            yield return waitForSeconds;
        }
    }
    
    private void AttackDetectedEnemy()
    {
        Enemy enemy = DetectEnemy();
        
        if (enemy != null)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Player attack enemy");
                lastAttackTime = Time.time;
            }
        }
        else
        {
            player.ChangeState(player.moveState);
        }
        
    }
    
    private Enemy DetectEnemy() 
    {
        //collider배열을 미리 만들어놓고 거기에 덮어쓰기 방식으로 결과를 채워줘서 새로운 메모리 할당X -> GC Alloc 0
        int count = Physics.OverlapSphereNonAlloc(playerTransform.position, attackRange, enemyColliders, enemyLayerMask);
        // Debug.Log("적 감지 개수:"+hits.Length);
        
        if (count > 0)
        {
            //한마리만 테스트
            return enemyColliders[0].GetComponent<Enemy>();  
        }

        return null;
    }
    
    public void Exit()
    {
        Debug.Log("Player Attack State Exit");

        if (detectCoroutine != null)
        {
            player.StopCoroutine(detectCoroutine);
        }
    }
}

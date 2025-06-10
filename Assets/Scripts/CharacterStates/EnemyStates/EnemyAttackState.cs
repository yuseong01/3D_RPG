using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState
{
    private Enemy enemy;
    private Player player;
    private Transform enemyTransform;
    private Transform playerTransform;
    private float attackRange;
    private int attackDamage;

    private float attackCooldown = 1f;
    private float lastAttackTime;

    private Coroutine attackCoroutine;
    private WaitForSeconds waitForSeconds;

    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemyTransform = enemy.transform;
        this.playerTransform = enemy.PlayerTransform;
        this.attackRange = enemy.AttackRange;
        this.attackDamage = enemy.AttackDamage;
        this.waitForSeconds = new WaitForSeconds(0.2f);
        
        player = playerTransform.GetComponent<Player>();
    }

    public void Enter()
    {
        Debug.Log("EnemyAttackState Enter");
        attackCoroutine = enemy.StartCoroutine(AttackCoroutine());
    }

    public void Tick()
    {
        // 공격 범위를 벗어나면 추적 상태로 전환
        float sqrDistance = (playerTransform.position - enemyTransform.position).sqrMagnitude;
        if (sqrDistance > attackRange * attackRange)
        {
            enemy.ChangeState(enemy.chaseState);
        }
    }

    public void Exit()
    {
        Debug.Log("EnemyAttackState Exit");
        if (attackCoroutine != null)
        {
            enemy.StopCoroutine(attackCoroutine);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            float sqrDistance = (playerTransform.position - enemyTransform.position).sqrMagnitude;
            if (sqrDistance <= attackRange * attackRange)
            {
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    Debug.Log("Enemy attacks player");
                    if (player != null)
                    {
                        player.TakeDamage(attackDamage);
                    }
                    lastAttackTime = Time.time;
                }
            }

            yield return waitForSeconds;
        }
    }
}

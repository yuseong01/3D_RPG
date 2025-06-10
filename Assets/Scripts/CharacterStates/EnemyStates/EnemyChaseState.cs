using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : IState
{
    private Enemy enemy;
    private Transform enemyTransform;
    private Transform playerTransform;
    private NavMeshAgent agent;

    private float attackRange;
    private float stopDistanceBuffer = 0.2f;

    public EnemyChaseState(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemyTransform = enemy.transform;
        this.playerTransform = enemy.PlayerTransform;
        this.agent = enemy.Agent;
        this.attackRange = enemy.AttackRange;
    }

    public void Enter()
    {
        Debug.Log("EnemyChaseState Enter");
        agent.isStopped = false;
    }

    public void Tick()
    {
        // 계속 플레이어 추적
        agent.SetDestination(playerTransform.position);

        // 거리 계산 (루트 없이)
        float sqrDistance = (playerTransform.position - enemyTransform.position).sqrMagnitude;
        float sqrAttack = (attackRange + stopDistanceBuffer) * (attackRange + stopDistanceBuffer);

        if (sqrDistance <= sqrAttack)
        {
            enemy.ChangeState(enemy.attackState);
        }
    }

    public void Exit()
    {
        Debug.Log("EnemyChaseState Exit");
        agent.isStopped = true;
    }
}

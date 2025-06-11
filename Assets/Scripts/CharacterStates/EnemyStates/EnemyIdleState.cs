using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : IState
{
    private Enemy enemy;
    private Transform enemyTransform;
    private Transform playerTransform;
    private NavMeshAgent agent;
    
    private float detectionRange = 5f;
    private float wanderCooldown = 2f;
    private float lastWanderTime;

    public EnemyIdleState(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemyTransform = enemy.transform;
        this.playerTransform = enemy.PlayerTransform;
        this.agent = enemy.Agent;
        this.detectionRange = enemy.DetectionRange;
    }

    public void Enter()
    {
        Debug.Log("EnemyIdleState Enter");
        Wander();
        lastWanderTime = Time.time;
    }

    public void Tick()
    {
        float now = Time.time;

        // 플레이어와 거리 계산 (sqrMagnitude 활용) 루트 없이 제곱기준 계산
        float sqrDistance = (playerTransform.position - enemyTransform.position).sqrMagnitude;
        float sqrDetection = detectionRange * detectionRange;

        if (sqrDistance <= sqrDetection)
        {
            enemy.ChangeState(enemy.chaseState);
            return;
        }

        // 주기적으로 방황
        if (now - lastWanderTime >= wanderCooldown)
        {
            Wander();
            lastWanderTime = now;
        }
    }

    public void Exit()
    {
        Debug.Log("EnemyIdleState Exit");
    }

    private void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(3f, 6f);
        randomDirection += enemyTransform.position;
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        
        lastWanderTime = Time.time;
    }
}

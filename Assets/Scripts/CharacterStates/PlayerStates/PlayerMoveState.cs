using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveState : IState
{
    private Player player;
    private PlayerStat playerStat;
    private Transform playerTransform;
    private NavMeshAgent agent;
    
    private int attackRange;
    private int detectRange;
    private float lastWanderTime;
    private float wanderCooldown = 2f;

    private int enemyLayerMask;
    private Collider[] enemyColliders = new Collider[10];

    public PlayerMoveState(Player player, PlayerStat playerStat)
    {
        this.player = player;
        this.playerStat = playerStat;
        this.playerTransform = player.CachedTransform;
        this.agent = player.Agent;
        this.attackRange = playerStat.AttackRange;
        this.detectRange = playerStat.DetectRange;

        this.enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    public void Enter()
    {
        Debug.Log("PlayerMoveState Enter");
        Wander();
        lastWanderTime = Time.time;
    }

    public void Tick()
    {
        float now = Time.time;

        int count = Physics.OverlapSphereNonAlloc(playerTransform.position, detectRange, enemyColliders, enemyLayerMask);

        if (count > 0)
        {
            Transform target = enemyColliders[0].transform;
            agent.SetDestination(target.position);

            float sqrDist = (target.position - playerTransform.position).sqrMagnitude;
            if (sqrDist <= attackRange * attackRange)
            {
                player.ChangeState(player.attackState);
                return;
            }
        }
        else
        {
            if (now - lastWanderTime > wanderCooldown)
            {
                Wander();
                lastWanderTime = now;
            }
        }
    }

    public void Exit()
    {
        Debug.Log("PlayerMoveState Exit");
    }

    private void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(3f, 6f);
        randomDirection += playerTransform.position;
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        
        lastWanderTime = Time.time;
    }
}

    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private Player player;
    private Transform playerTransform;
    private float attackRange;
    private int attackDamage = 10;

    private float attackCooldown = 1f;
    private float lastAttackTime;

    public PlayerAttackState(Player player)
    {
        this.player = player;
        this.playerTransform = player.CachedTransform;
        this.attackRange = player.AttackRange;
    }

    public void Enter()
    {
        Debug.Log("PlayerAttack State Enter");
    }

    public void Tick()
    {
        Debug.Log("때리는중");
        //범위 안에 들어온 Collider배열에 담아줌(OverlapSphere(position, radius, layerMask)
        Collider[] hits = Physics.OverlapSphere(playerTransform.position, attackRange, LayerMask.GetMask("Enemy"));
        Debug.Log("적 감지 개수:"+hits.Length);
        
        if (hits.Length > 0)
        {
            //한마리만 테스트
            Enemy enemy = hits[0].GetComponent<Enemy>();
            if (enemy == null)
            {
                Debug.Log("Enemy컴포넌트를 못찾음");
            }
            if (enemy != null)
            {
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    enemy.TakeDamage(attackDamage);
                    Debug.Log("Player attack enemy");
                    lastAttackTime = Time.time;
                }
            }
        }
        else
        {
            player.ChangeState(player.moveState);
        }
    }

    public void Exit()
    {
        Debug.Log("Player Attack State Exit");
    }
}

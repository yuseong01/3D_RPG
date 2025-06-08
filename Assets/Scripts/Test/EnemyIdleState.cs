using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    private Enemy enemy;

    public EnemyIdleState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("EnemyIdleState Enter");
    }

    public void Tick()
    {
        Debug.Log("EnemyIdleState Tick ");
    }

    public void Exit()
    {
        Debug.Log("EnemyIdleState Exit");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IState
{
    private Enemy enemy;
    public EnemyChaseState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("EnemyChaseState Enter");
    }

    public void Tick()
    {
        Debug.Log("EnemyChaseState Tick");
    }

    public void Exit()
    {
        Debug.Log("EnemyChaseState Exit");
    }
}

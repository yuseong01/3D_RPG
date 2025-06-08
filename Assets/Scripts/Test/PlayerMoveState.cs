using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IState
{
    private Player player;

    public PlayerMoveState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("PlayerMoveState Enter");
    }

    public void Tick()
    {
        Debug.Log("PlayerMoveState Tick");
    }

    public void Exit()
    {
        Debug.Log("PlayerMoveState Exit");
    }
}

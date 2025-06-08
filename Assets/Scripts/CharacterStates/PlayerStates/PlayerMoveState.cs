using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IState
{
    private Player player;
    private Transform playerTransform;
    private float moveSpeed;

    public PlayerMoveState(Player player)
    {
        this.player = player;
        this.playerTransform = player.transform;
        this.moveSpeed = player.MoveSpeed;
    }

    public void Enter()
    {
        Debug.Log("PlayerMoveState Enter");
    }

    public void Tick()
    {
        playerTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void Exit()
    {
        Debug.Log("PlayerMoveState Exit");
    }
}

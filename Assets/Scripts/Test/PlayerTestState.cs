using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : IState
{
    public void Enter()
    {
        Debug.Log("Enter");
    }

    public void Tick()
    {
        Debug.Log("Tick");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}

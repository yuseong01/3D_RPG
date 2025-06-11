using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : StateMachine
{
    private void Start()
    {
        ChangeState(new PlayerTestState());
    }
}

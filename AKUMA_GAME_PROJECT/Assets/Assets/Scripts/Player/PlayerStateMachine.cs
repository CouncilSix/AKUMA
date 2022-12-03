using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{

    //{get; private set;} = any other script that has a reference to this player state can use it, but only this script can set it.
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

}

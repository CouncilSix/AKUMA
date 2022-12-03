using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {

    }

    public override void Enter()
    {

        player.SetVelocityX(0f);
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {

        if (input.x != 0f)
        {
            //stateMachine.ChangeState(player.MoveState); Use this code to tell the player which state to change to. SICK!!
            stateMachine.ChangeState(player.MoveState);
            Debug.Log("Player is moving.");

        }
    }

    public override void PhysicsUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
 
    }

    public override void Enter()
    {
  
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {


        //player.CheckIfShouldFlip(xInput);

        //ADD .Normalized here to complete the check appropriately, but remove the .normalized from Input Handler to allow variable speed.
        //player.SetVelocityX(PlayerData.movementVelocity * xInput);
        player.SetVelocityX(PlayerData.movementVelocity * input.x);

        Debug.Log("Move Output!");

        if (input.x == 0f)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
   
    }
}

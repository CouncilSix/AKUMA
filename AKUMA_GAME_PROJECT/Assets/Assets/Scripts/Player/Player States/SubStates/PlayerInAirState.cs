using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{

    private Vector2 input;
    private bool isGrounded;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool coyoteTime;
    private bool isJumping;


    public PlayerInAirState(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

        input = player.InputHandler.MovementInput;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;

        CheckJumpMultiplier();


        if(isGrounded && player.CurrentVelocity.y<0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        {
            //can set different movement freedoms here while airborne
            player.SetVelocityX(PlayerData.movementVelocity * input.x * Time.deltaTime);
        }
    }

    private void CheckJumpMultiplier()
    {
        if  (isJumping)
        {
            if  (jumpInputStop)
            {
                player.setVelocityY(player.CurrentVelocity.y * PlayerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if(player.CurrentVelocity.y<=0f)    
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private void CheckCoyoteTime()
    {
    if(coyoteTime &&Time.time > startTime + PlayerData.coyoteTime)
        {
        coyoteTime = false;
        player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

public void StartCoyoteTime() => coyoteTime = true;

public void SetIsJumping() => isJumping = true;

}

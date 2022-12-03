using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{

    private int amountOfJumpsLeft;


    public PlayerJumpState(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.setVelocityY(PlayerData.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();

    }

    public bool CanJump()
    {
        if (amountOfJumpsLeft>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = PlayerData.amountOfJumps;

    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft --;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationHandler : PlayerState
{
    public PlayerAnimationHandler(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    #region Animation Components
    private Rigidbody2D rb;
    private Animator animator;
    private AnimationState animationState;
    private string currentState;
    #endregion

    #region Animation States
    //Create State Objects Here:=================
    private PlayerIdleState IdleState;
    private PlayerMoveState MoveState;
    private PlayerJumpState JumpState;
    private PlayerInAirState InAirState;
    private PlayerLandState LandState;
    #endregion

    void ChangeAnimationState(string newState)
    {
        //Stop the same animation from interrupting itself
        if (currentState == newState) return;

        //Play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    //    //=====================================================
    //    // ANIMATION STATE TESTS
    //    //=====================================================
    const string Player_idle = "Player_idle";
    const string Player_run = "Player_run";
    const string Player_jump = "Player_jump";
    const string Player_attack = "Player_attack";

    #region Animation Constant Strings
    //    //=====================================================
    //    // ANIMATION STATES (UNEQUIPPED LEFT & RIGHT)
    //    //=====================================================
    //    //MOVEMENT STATES (GROUNDED & STANDING)
    //    const string PLAYER_A_IDLE_LEFT = "A_Idle_Left";
    //    const string PLAYER_A_IDLE2WALK_LEFT = "A_Idle2Walk__Left";
    //    const string PLAYER_A_WALK_LEFT = "A_Walk_Left";
    //    const string PLAYER_A_JOG_LEFT = "A_Jog_Left";
    //    const string PLAYER_A_RUN_LEFT = "A_Run_Left";
    //    const string PLAYER_A_INJUREDRUN_LEFT = "A_InjuredRun_Left";

    //    const string PLAYER_A_IDLE_RIGHT = "A_Idle_Right";
    //    const string PLAYER_A_IDLE2WALK_RIGHT = "A_Idle2Walk__Right";
    //    const string PLAYER_A_WALK_RIGHT = "A_Walk_Right";
    //    const string PLAYER_A_JOG_RIGHT = "A_Jog_Right";
    //    const string PLAYER_A_RUN_RIGHT = "A_Run_Right";
    //    const string PLAYER_A_INJUREDRUN_RIGHT = "A_InjuredRun_Right";

    //    //MOVEMENT STATES (CROUCHED & AIRBORNE)
    //    const string PLAYER_A_IDLE2CROUCH_LEFT = "A_Idle2Crouch_Left";
    //    const string PLAYER_A_IdleCrouch_Left = "A_IdleCrouch_Left";
    //    const string PLAYER_A_CrouchForward_Left = "A_CrouchForward_Left";

    //    const string PLAYER_A_IDLE2CROUCH_RIGHT = "A_Idle2Crouch_Right";
    //    const string PLAYER_A_IdleCrouch_RIGHT = "A_IdleCrouch_Right";
    //    const string PLAYER_A_CrouchForward_RIGHT = "A_CrouchForward_Right";

    //    const string PLAYER_A_JUMP1_LEFT = "A_Jump1_Left";
    //    const string PLAYER_A_JUMP2_LEFT = "A_Jump2_Left";

    //    const string PLAYER_A_JUMP1_RIGHT = "A_Jump1_Right";
    //    const string PLAYER_A_JUMP2_RIGHT = "A_Jump2_Right";

    //    //=====================================================
    //    // ANIMATION STATES (EQUIPPED LEFT & RIGHT)
    //    //=====================================================

    //    //MOVEMENT STATES (GROUNDED & STANDING)
    //    const string PLAYER_B_IDLE_LEFT = "A_Idle_Left";
    //    const string PLAYER_B_IDLE2WALK_LEFT = "A_Idle2Walk__Left";
    //    const string PLAYER_B_WALK_LEFT = "A_Walk_Left";
    //    const string PLAYER_B_JOG_LEFT = "A_Jog_Left";
    //    const string PLAYER_B_RUN_LEFT = "A_Run_Left";
    //    const string PLAYER_B_INJUREDRUN_LEFT = "A_InjuredRun_Left";

    //    const string PLAYER_B_IDLE_RIGHT = "A_Idle_Right";
    //    const string PLAYER_B_IDLE2WALK_RIGHT = "A_Idle2Walk__Right";
    //    const string PLAYER_B_WALK_RIGHT = "A_Walk_Right";
    //    const string PLAYER_B_JOG_RIGHT = "A_Jog_Right";
    //    const string PLAYER_B_RUN_RIGHT = "A_Run_Right";
    //    const string PLAYER_B_INJUREDRUN_RIGHT = "A_InjuredRun_Right";

    //    //MOVEMENT STATES (CROUCHED & AIRBORNE)
    //    const string PLAYER_B_IDLE2CROUCH_LEFT = "A_Idle2Crouch_Left";
    //    const string PLAYER_B_IdleCrouch_Left = "A_IdleCrouch_Left";
    //    const string PLAYER_B_CrouchForward_Left = "A_CrouchForward_Left";

    //    const string PLAYER_B_IDLE2CROUCH_RIGHT = "A_Idle2Crouch_Right";
    //    const string PLAYER_B_IdleCrouch_RIGHT = "A_IdleCrouch_Right";
    //    const string PLAYER_B_CrouchForward_RIGHT = "A_CrouchForward_Right";

    //    const string PLAYER_B_JUMP1_LEFT = "A_Jump1_Left";
    //    const string PLAYER_B_JUMP2_LEFT = "A_Jump2_Left";

    //    const string PLAYER_B_JUMP1_RIGHT = "A_Jump1_Right";
    //    const string PLAYER_B_JUMP2_RIGHT = "A_Jump2_Right";

    //    //=========================================================================
    //    //=========================================================================
    //    //=========================================================================
    #endregion

    private void Update()
    {
        if (stateMachine.CurrentState == IdleState)
        {
            ChangeAnimationState(Player_idle);
        }
        if (stateMachine.CurrentState == MoveState)
        {
            ChangeAnimationState(Player_run);
        }
        if (stateMachine.CurrentState == JumpState)
        {
            ChangeAnimationState(Player_jump);
        }
        if (stateMachine.CurrentState == InAirState)
        {
            ChangeAnimationState(Player_jump);
        }
        if (stateMachine.CurrentState == LandState)
        {
          //  ChangeAnimationState(Player_land);
        }
    }

    private void FixedUpdate()
    {
    }
}
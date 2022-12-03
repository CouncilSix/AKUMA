using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected CorePlayer player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData PlayerData;

    protected bool isAnimationFinished;

    protected float startTime;

    private string animBoolName;


    public PlayerState(CorePlayer player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.PlayerData = playerData;
        this.animBoolName = animBoolName;

    }
    //=============================================================================
    // Enter is called when entering a state
    //=============================================================================
    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        UnityEngine.Debug.Log(animBoolName);
        isAnimationFinished = false;
    }

    //=============================================================================
    // Exit is called when exiting a state
    //=============================================================================
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }
    //=============================================================================
    // LogicUpdate is called every frame (also known as Update)
    //=============================================================================
    public virtual void LogicUpdate(){}

    //=============================================================================
    // PhysicsUpdate is called every fixed updated (also known as FixedUpdate)
    //=============================================================================
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks(){ }
    public virtual void AnimationTrigger(){ }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}

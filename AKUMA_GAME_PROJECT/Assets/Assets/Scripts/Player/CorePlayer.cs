
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CorePlayer : MonoBehaviour
{
    //====================================================================
    #region State Variables

    [SerializeField] private PlayerData playerData;

    public PlayerStateMachine StateMachine { get; private set; }

    //Create State Objects Here:=================
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    //    //TODO: Store Our Actions
    //    public PlayerJumpState JumpState { get; private set; }

    //    public PlayerCrouchState CrouchState { get; private set; }
    //    public PlayerInteractState InteractState { get; private set; }


    //    public InputAction BlockAction;
    //    public InputAction DrawStowSwordAction;
    //    public InputAction UseGearAction;
    //    public InputAction AttackAction;
    //    public InputAction PauseGameAction;
    //    public InputAction InventoryAction;
    //    public InputAction GearWestAction;
    //    public InputAction GearNorthAction;
    //    public InputAction GearEastAction;
    //    public InputAction GearSouthAction;
    //============================================

    #endregion
    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;

    #endregion

    #region Other Variables
    //Velocity Parameters
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;

    //Record Player Direction
    public int FacingDirection { get; private set; }

    #endregion
    //====================================================================
    #region Unity Callback Functions
    ////=======================================================================
    //// Awake is called before the first update(INITIALIZE HERE)
    ////=======================================================================
    private void Awake()
    {

    StateMachine = new PlayerStateMachine();
    //add all player states here to match the objects above:
    IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
    MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
    InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
    LandState = new PlayerLandState(this, StateMachine, playerData, "land");

    }
    //=========================================================================
    // Start is called before the first frame update (At Game Start)
    //=========================================================================
    private void Start()
    {   //INITIALIZE HERE
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        //FacingDirection = 1;

        StateMachine.Initialize(IdleState);

    }

    ////=======================================================================
    //// Update is called once per frame (Inputs)
    ////=======================================================================
    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    ////=======================================================================
    //// FixedUpdate is called based on time (Physics)
    ////=======================================================================
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion
    //====================================================================
    #region Set Functions
    //use this function to change velocity of the player
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void setVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    #endregion
    //====================================================================
    #region Check Functions
    //Use these functions to check each direction and then flip accordingly.
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.GroundCheckRadius, playerData.whatIsGround);
    }

    #endregion
    //====================================================================
    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    #endregion
}
//========================================================================
#region All The Stuff
//    [Header("Attachables")]
//    [SerializeField] private ParticleSystem deathParticles;
//    [SerializeField] private GameObject graphic;
//    [SerializeField] private Component[] graphicSprites;
//    [SerializeField] private ParticleSystem jumpParticles;
//    [SerializeField] private GameObject pauseMenu;
//    [SerializeField] private GameObject inventoryMenu;
//    [SerializeField] public GameObject attackHit;
//    [SerializeField] public CameraEffects cameraEffects;
//    [SerializeField] public RecoveryCounter recoveryCounter;
//    [SerializeField] private string[] cheatItems;
//    [SerializeField] public AudioSource audioSource;

//    // Singleton instantiation

//    [Header("Inventory")]
//    public float ammo;
//    public int coins;
//    public int health;
//    public int maxHealth;
//    public int maxAmmo;
//    public int maxPoise;

//    //Manage Sound Effects
//    //[Header("Sounds")]
//    //public AudioClip deathSound;
//    //public AudioClip equipSound;
//    //public AudioClip grassSound;
//    //public AudioClip hurtSound;
//    //public AudioClip[] hurtSounds;
//    //public AudioClip holsterSound;
//    //public AudioClip jumpSound;
//    //public AudioClip landSound;
//    //public AudioClip poundSound;
//    //public AudioClip punchSound;
//    //public AudioClip[] poundActivationSounds;
//    //public AudioClip outOfAmmoSound;
//    //public AudioClip stepSound;
//    //[System.NonSerialized] public int whichHurtSound;
#endregion
//========================================================================
#region Cheat Items & Sound FX
//=====================================================
// Cheat Items for Testing Purposes
//=====================================================


//public void SetUpCheatItems()

//{
//    //Allows us to get various items immediately after hitting play, allowing for testing. 
//    for (int i = 0; i < cheatItems.Length; i++)
//    {
//        GameManager.Instance.GetInventoryItem(cheatItems[i], null);
//    }
//}

//=====================================================
// Sound Effect Options
//=====================================================

//public void SetGroundType()
//{
//    //If we want to add variable ground types with different sounds, it can be done here
//    //switch ()
//    {
//        //   case "Grass":
//        //       stepSound = grassSound;
//        //       break;
//    }
//}

////Further control of the footstep audio played.
//public void PlayStepSound()
//{
//    //Play a step sound at a random pitch between two floats, while also increasing the volume based on the Horizontal axis
//    //AudioSource.pitch? = Random.Range(0.9f, 1.1f);
//    //AudioSource.PlayOneShot(stepSound, Mathf.Abs(Input.GetAxis("Horizontal") / 10));
//}
////Control over Jump Sounds & Effects
//public void PlayJumpSound()
//{
//    audioSource.pitch = (Random.Range(1f, 1f));
//    GameManager.Instance.audioSource.PlayOneShot(jumpSound, .1f);
//}

//public void JumpEffect()
//{
//    jumpParticles.Emit(1);
//    audioSource.pitch = (Random.Range(0.6f, 1f));
//    audioSource.PlayOneShot(landSound);
//}

//public void LandEffect()
//{
//    if (!isGrounded)
//    {
//        jumpParticles.Emit(1);
//        audioSource.pitch = (Random.Range(0.6f, 1f));
//        audioSource.PlayOneShot(landSound);
//        isGrounded = true;
//    }
#endregion

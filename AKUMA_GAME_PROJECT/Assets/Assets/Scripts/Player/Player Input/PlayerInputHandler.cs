using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 MovementInput { get; private set; }

    public int InputY { get; private set; }

    public Vector2 InputX { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;

    #region Update Functions
    //=====================================================
    // Awake is called as the game is loading
    //=====================================================
    private void Awake()
    {

    }

    //ON INPUT ENABLE
    void OnEnable()
    {

    }

    //ON INPUT DISABLE
    private void OnDisable()
    {

    }

    //=====================================================
    // Start is called before the first frame update
    //=====================================================
    private void Start()
    {

    }

    //=====================================================
    // Update is called once per frame
    //=====================================================
    private void Update()
    {
        CheckJumpInputHoldTime();
    }
    //=====================================================
    // FixedUpdate is called based on time
    //=====================================================
    private void FixedUpdate()
    {

    }

    #endregion

    ////FOR DEBUGGING CONTEXT ISSUES:
    //if (context.started)
    //{
    //    UnityEngine.Debug.Log("Jump button was pushed down");
    //}

    //if (context.performed)
    //{
    //UnityEngine.Debug.Log("Jump button is being held down");
    //}

    //if (context.started)
    //{
    //UnityEngine.Debug.Log("Jump button was released");
    //}

    //========================================================================
    //MOVEMENT INPUTS=========================================================
    //========================================================================

    //Moving Left/Right=======================

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        InputX = MovementInput;
        InputY = (int)(MovementInput * Vector2.up).normalized.y;

        UnityEngine.Debug.Log("Move Input" +MovementInput);
    }

    //Jumping=================================
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
            UnityEngine.Debug.Log("Jump button was pushed down");
        }
        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    //Crouching===============================
    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Crouch Input!" + context);
    }

    //Dodging=================================

    ////========================================
    ////BUTTON INPUTS===========================
    ////========================================

    //Interact================================
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Interact Input!" + context);
    }

    //Block===================================
    public void OnBlockInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Block Input!" + context);
    }

    //Draw/Stow Sword=========================
    public void OnDrawStowSwordInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Draw & Stow Sword Input!" + context);
    }

    //Use Gear================================
    public void OnUseGearInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Use Gear Input!" + context);
    }

    //Attack==================================
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Attack Input!" + context);
    }

    //========================================
    //MENU INPUTS=============================
    //========================================

    //Pause Game==============================
    public void OnPauseGameInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Pause Input!" + context);
    }


    //InventoryInput==========================
    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Inventory Input!" + context);
    }

    //========================================
    //QUICK-SELECT GEAR INPUTS================
    //========================================

    //Select Gear West========================
    public void OnGearWestInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Gear West Input!" + context);
    }

    //Select Gear North=======================
    public void OnGearNorthInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Gear North Input!" + context);
    }

    //Select Gear East========================
    public void OnGearEastInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Gear East Input!" + context);
    }

    //Select Gear South=======================
    public void OnGearSouthInput(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Gear South Input!" + context);
    }

    //=========================================================================

}



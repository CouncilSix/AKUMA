using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Movement State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Check Variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask whatIsGround;



    ////Store Our Variables
    //[Header("Player Physics")]
    //[SerializeField] private float jumpHeight = 10f;
    //[SerializeField] public float movementVelocity = 10f;
    //[SerializeField] private float dashDistance = 8f;
    //[SerializeField] private float attackRange = 1f;
    //[SerializeField] private float airHangTime = 1f;
    //[SerializeField] private float wallHangTime = 1f;
    //[SerializeField] private float attackDelay = 0.3f;
    //[SerializeField] private float MaxHealth = 5;
    //[SerializeField] private float MaxPoise = 1;

    //[Header("Movement Parameters")]
    //[Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    //[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;  // How much to smooth out the movement
    //[SerializeField] private bool AirControl = false;                         // Whether or not a player can steer while jumping;
    //[SerializeField] private LayerMask WhatIsGround;                          // A mask determining what is ground to the character
    //[SerializeField] private Transform GroundCheck;                           // A position marking where to check if the player is grounded.
    //[SerializeField] private Transform CeilingCheck;                          // A position marking where to check for ceilings
    //[SerializeField] private Collider2D CrouchDisableCollider;                // A collider that will be disabled when crouching


    //[Header("Attachables")]
    //[SerializeField] private ParticleSystem deathParticles;
    //[SerializeField] private GameObject graphic;
    //[SerializeField] private Component[] graphicSprites;
    //[SerializeField] private ParticleSystem jumpParticles;
    //[SerializeField] private GameObject pauseMenu;
    //[SerializeField] public GameObject attackHit;
    //[SerializeField] public CameraEffects cameraEffects;
    //[SerializeField] public RecoveryCounter recoveryCounter;
    //[SerializeField] private string[] cheatItems;
    //[SerializeField] public AudioSource audioSource;

    //// Singleton instantiation

    //[Header("Inventory")]
    //public float ammo;
    //public int coins;
    //public int health;
    //public int maxHealth;
    //public int maxAmmo;

    ////Manage Sound Effects
    //[Header("Sounds")]
    //public AudioClip deathSound;
    //public AudioClip equipSound;
    //public AudioClip grassSound;
    //public AudioClip hurtSound;
    //public AudioClip[] hurtSounds;
    //public AudioClip holsterSound;
    //public AudioClip jumpSound;
    //public AudioClip landSound;
    //public AudioClip poundSound;
    //public AudioClip punchSound;
    //public AudioClip[] poundActivationSounds;
    //public AudioClip outOfAmmoSound;
    //public AudioClip stepSound;
    //[System.NonSerialized] public int whichHurtSound;
}

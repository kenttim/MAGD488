using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //dodge stuff
    InputHandler inputHandler;
    Animator anim;
    CameraHandler cameraHandler;
    PlayerLocomotion playerLocomotion;

    [Header("Player Flags")]
    public bool rollFlag; //dodge stuff
    public bool isInAir; // fall stuff
    public bool isGrounded; // fall stuff
    public bool isInteracting; //dodge stuff
    public bool isSprinting; //sprinting stuff

    private void Awake()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
    }
    void Start()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>(); // fall stuff
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = anim.GetBool("isInteracting"); //restructure error for later

        inputHandler.TickInput(delta);
        playerLocomotion.HandleMovement(delta);
        playerLocomotion.HandleRollAndSprint(delta);  //dodge stuff

        anim.SetBool("isInAir", isInAir); // jump stuff

        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        playerLocomotion.HandleJumping(); // jump stuff
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }
    }

    private void LateUpdate() // fall stuff
    {
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        inputHandler.left_click = false;
        inputHandler.right_click = false;
        inputHandler.jump_input = false; // jump stuff

        if (isInAir) 
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime; // fall stuff
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //dodge stuff
    InputHandler inputHandler;
    Animator anim;
    PlayerLocomotion playerLocomotion;

    public bool isInAir; // fall stuff
    public bool isGrounded; // fall stuff
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
        inputHandler.isInteracting = anim.GetBool("isInteracting"); //restructure error for later

        anim.SetBool("isInAir", isInAir); // jump stuff

        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        playerLocomotion.HandleJumping(); // jump stuff
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

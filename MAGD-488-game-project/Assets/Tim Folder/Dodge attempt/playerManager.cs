using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
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
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
    }

    private void LateUpdate() // fall stuff
    {
        if (isInAir) 
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime; // fall stuff
        }
    }
}

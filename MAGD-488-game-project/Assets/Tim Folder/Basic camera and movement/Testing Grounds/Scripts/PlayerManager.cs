using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    //dodge stuff
    InputHandler inputHandler;
    Animator anim;
    CameraHandler cameraHandler;
    PlayerLocomotion playerLocomotion;
    PlayerStats playerStats;
    InteractableUI interactableUI;
    public GameObject interactableUIGameObject;
    public GameObject itemInteractableGameObject;

    [Header("Player Flags")]
    public bool rollFlag; //dodge stuff
    public bool isInAir; // fall stuff
    public bool isGrounded; // fall stuff
    public bool isInteracting; //dodge stuff
    public bool isSprinting; //sprinting stuff
    public bool isUsingRightHand; //weapon stuff
    public bool isUsingLeftHand; //weapon stuff
    public bool canDoCombo;

    private void Awake()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
    }
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerLocomotion = GetComponent<PlayerLocomotion>(); // fall stuff
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        interactableUI = FindObjectOfType<InteractableUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = anim.GetBool("isInteracting"); //restructure error for later
        canDoCombo = anim.GetBool("canDoCombo");
        isUsingRightHand = anim.GetBool("isUsingRightHand"); // both are for weapon stuff
        isUsingLeftHand = anim.GetBool("isUsingLeftHand");
        anim.SetBool("isInAir", isInAir); // jump stuff
        isFiring = anim.GetBool("isFiring");
      

        inputHandler.TickInput(delta);
        playerLocomotion.HandleRollAndSprint(delta);  //dodge stuff
        playerLocomotion.HandleJumping(); // jump stuff

        playerStats.StaminaRegen();

        CheckForInteractable();
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        playerLocomotion.HandleMovement(delta);
        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
    }

    private void LateUpdate() // fall stuff
    {
        inputHandler.rollFlag = false;
        inputHandler.left_click = false;
        inputHandler.right_click = false;
        inputHandler.jump_input = false; // jump stuff
        inputHandler.interact_input = false;

        float delta = Time.deltaTime;

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }

        if (isInAir) 
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime; // fall stuff
        }
    }

    public void CheckForInteractable()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 2f, cameraHandler.ignoreLayers))
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText;

                    interactableUI.interactableText.text = interactableText;
                    interactableUIGameObject.SetActive(true);

                    if (inputHandler.interact_input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
            }
            
        }
        else
        {
            if(interactableUIGameObject != null)
            {
                interactableUIGameObject.SetActive(false);
            }

            if(itemInteractableGameObject != null && inputHandler.interact_input)
            {
                itemInteractableGameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_input; //dodge stuff
    public bool rollFlag; //dodge stuff
    

    public bool left_click; //attack stuff
    public bool right_click; //attack stuff

    public bool jump_input;

    public bool interact_input;

    /*
    public float clickTimer; //attack stuff
    public bool holdClickFlag; //attack stuff
    public bool lightAttackFlag; //attack stuff
    public bool heavyAttackFlag; //attack stuff
    */

    public float rollInputTimer; //sprinting stuff
    public bool sprintFlag; //sprinting stuff

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    CameraHandler cameraHandler;
    PlayerStats playerStats;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerStats = GetComponent<PlayerStats>();
    }

    public void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            
            inputActions.PlayerActions.LeftClick.performed += i => left_click = true;
            inputActions.PlayerActions.RightClick.performed += i => right_click = true;
            inputActions.PlayerActions.Jump.performed += i => jump_input = true;
            inputActions.PlayerActions.Interact.performed += i => interact_input = true;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);  //dodge stuff
        HandleAttackInput(delta);
    }

    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleRollInput(float delta)  //dodge stuff
    {
        b_input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        sprintFlag = b_input;

        if (b_input)
        {
            rollInputTimer += delta;
        }
        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.2f)
            {
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleAttackInput(float delta) //attack stuff
    {
        
        if (left_click)
        {
            int lightAttackStaminaMinimum = Mathf.RoundToInt(playerInventory.leftWeapon.baseStamina * playerInventory.leftWeapon.lightAttackMultiplier);
            
            if(playerStats.currentStamina >= lightAttackStaminaMinimum)
            {
                playerAttacker.HandleLightMeleeAttack(playerInventory.leftWeapon);
            }
            else
            {
                Debug.Log("Out of stamina");
            }    
        } 
        
        if (right_click)
        {
            int heavyAttackStaminaMinimum = Mathf.RoundToInt(playerInventory.rightWeapon.baseStamina * playerInventory.rightWeapon.heavyAttackMultiplier);
            
            if (playerStats.currentStamina >= heavyAttackStaminaMinimum)
            {
                playerAttacker.HandleHeavyMeleeAttack(playerInventory.rightWeapon);
            }
            else
            {
                Debug.Log("Out of stamina");
            }
        }
     


        /*
        left_click = inputActions.PlayerActions.LeftClick.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        while(left_click)
        {
            clickTimer += delta;
        }
        if (clickTimer > 0 && clickTimer < 0.5f && left_click == false)
        {
            lightAttackFlag = true;
            clickTimer = 0;
        } else if (clickTimer > 0.5f && left_click == false)
        {
            heavyAttackFlag = true;
            clickTimer = 0;
        }


        if (lightAttackFlag == true)
        {
            playerAttacker.HandleLightMeleeAttack(playerInventory.leftWeapon);
            lightAttackFlag = false;
            heavyAttackFlag = false;
        }

        if (heavyAttackFlag == true)
        {
            playerAttacker.HandleHeavyMeleeAttack(playerInventory.leftWeapon);
            lightAttackFlag = false;
            heavyAttackFlag = false;
        }*/

    }

}



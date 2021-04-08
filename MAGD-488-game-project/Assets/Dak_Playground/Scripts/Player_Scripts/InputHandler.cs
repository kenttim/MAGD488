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

    public bool lockOnFlag;
    public bool lockOnInput;

    
    public float clickTimer; //attack stuff
    public bool holdClickFlag; //attack stuff
    

    public float rollInputTimer; //sprinting stuff
    public bool sprintFlag; //sprinting stuff

    public bool right_Arrow_Input;
    public bool left_Arrow_Input;

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    CameraHandler cameraHandler;
    PlayerStats playerStats;
    AnimatorHandler animatorHandler;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponentInChildren<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerStats = GetComponent<PlayerStats>();
        cameraHandler = FindObjectOfType<CameraHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
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
            inputActions.PlayerActions.LockOn.performed += i => lockOnInput = true;
            inputActions.PlayerMovement.LockOnTargetRight.performed += i => right_Arrow_Input = true;
            inputActions.PlayerMovement.LockOnTargetLeft.performed += i => left_Arrow_Input = true;
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
        HandleLockOnInput();
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
        /*
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
            int heavyAttackStaminaMinimum = Mathf.RoundToInt(playerInventory.leftWeapon.baseStamina * playerInventory.leftWeapon.heavyAttackMultiplier);
            
            if (playerStats.currentStamina >= heavyAttackStaminaMinimum)
            {
                playerAttacker.HandleHeavyMeleeAttack(playerInventory.leftWeapon);
            }
            else
            {
                Debug.Log("Out of stamina");
            }
        }
     */

        left_click = inputActions.PlayerActions.LeftClick.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        if(left_click)
        {
            clickTimer += delta;
        }
        if (clickTimer > 0 && clickTimer < 0.5f && left_click == false)
        {
            int lightAttackStaminaMinimum = Mathf.RoundToInt(playerInventory.leftWeapon.baseStamina * playerInventory.leftWeapon.lightAttackMultiplier);
            clickTimer = 0;

            if (playerStats.currentStamina >= lightAttackStaminaMinimum)
            {
                animatorHandler.anim.SetBool("isUsingLeftHand", true);
                playerAttacker.HandleLightMeleeAttack(playerInventory.leftWeapon);
                
            }
            else
            {
                Debug.Log("Out of stamina");
            }

        } else if (clickTimer > 0.5f && left_click == false)
        {
            int heavyAttackStaminaMinimum = Mathf.RoundToInt(playerInventory.leftWeapon.baseStamina * playerInventory.leftWeapon.heavyAttackMultiplier);
            clickTimer = 0;

            if (playerStats.currentStamina >= heavyAttackStaminaMinimum)
            {
                animatorHandler.anim.SetBool("isUsingLeftHand", true);
                playerAttacker.HandleHeavyMeleeAttack(playerInventory.leftWeapon);
               
            }
            else
            {
                Debug.Log("Out of stamina");
            }

        }

        if (right_click)
        {
            playerAttacker.HandleRangeAttack();
            //animatorHandler.anim.SetBool("isUsingRightHand", true);
        }

    }

    private void HandleLockOnInput()
    {
        if(lockOnInput && lockOnFlag == false)
        {
            
            lockOnInput = false;
            cameraHandler.HandleLockOn();

            if(cameraHandler.nearestLockOnTarget != null)
            {
                cameraHandler.currentLockOnTarget = cameraHandler.nearestLockOnTarget;
                lockOnFlag = true;
            }

        }
        else if(lockOnInput && lockOnFlag == true)
        {
            lockOnInput = false;
            lockOnFlag = false;
            cameraHandler.ClearLockOnTargets();
        }

        if(lockOnFlag && left_Arrow_Input)
        {
            left_Arrow_Input = false;
            cameraHandler.HandleLockOn();
            if(cameraHandler.leftLockTarget != null)
            {
                cameraHandler.currentLockOnTarget = cameraHandler.leftLockTarget;
            }
        }
        if(lockOnFlag && right_Arrow_Input)
        {
            right_Arrow_Input = false;
            cameraHandler.HandleLockOn();
            if (cameraHandler.rightLockTarget != null)
            {
                cameraHandler.currentLockOnTarget = cameraHandler.rightLockTarget;
            }

        }

        cameraHandler.SetCameraHeight();
    }
}



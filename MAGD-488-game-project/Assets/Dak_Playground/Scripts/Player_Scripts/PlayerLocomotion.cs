using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Transform cameraObject;
    InputHandler inputHandler;
    Vector3 moveDirection;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorHandler animatorHandler;

    public new Rigidbody rigidbody;
    public GameObject normalCamera;

    [Header("Movement Stats")]
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float sprintSpeed = 7; //sprinting stuff
    [SerializeField]
    float rotationSpeed = 10;

    public bool isSprinting; //sprinting stuff

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        cameraObject = Camera.main.transform;
        myTransform = transform;
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        animatorHandler.Initialize();
    }

    #region Movement

    Vector3 normalVector;
    Vector3 targetPosition;

    private void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;
        float moveOverride = inputHandler.moveAmount;

        targetDir = cameraObject.forward * inputHandler.vertical;
        targetDir += cameraObject.right * inputHandler.horizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
            targetDir = myTransform.forward;

        float rs = rotationSpeed;
        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }

    public void HandleMovement(float delta)
    {
        if (inputHandler.rollFlag) //sprinting stuff
        {
            return;
        }
        moveDirection = cameraObject.forward * inputHandler.vertical;
        moveDirection += cameraObject.right * inputHandler.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;

        if (inputHandler.sprintFlag) //sprinting stuff
        {
            speed = sprintSpeed;
            isSprinting = true;
            moveDirection *= speed;
        } else
        {
            moveDirection *= speed;
        } //sprinting stuff



        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVelocity;

        //when animations are added                                     //sprinting stuff
        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, isSprinting);

        if (animatorHandler.canRotate)
        {
            HandleRotation(delta);
        }
    }

    #endregion

    public void Update()
    {
        float delta = Time.deltaTime;

        isSprinting = inputHandler.b_input;

        inputHandler.TickInput(delta);

        HandleMovement(delta); 

        HandleRollAndSprint(delta);  //dodge stuff

    }

    public void HandleRollAndSprint(float delta)  //dodge stuff
    {
        if (animatorHandler.anim.GetBool("isInteracting"))
        {
            return;
        }
        if (inputHandler.rollFlag)
        {
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;

            if(inputHandler.moveAmount >= 0)
            {
                animatorHandler.PlayTargetAnimation("Roll", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
            }
        }
    }
}

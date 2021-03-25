using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{

    EnemyLocomotionManager enemyLocomotionManager;

    public bool isPerformingAction;

    [Header("A.I. Settings")]
    public float detectionRadius = 20;
    //the higher the maximum and lower the minimum the greater the fov becomes
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;


    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if (enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        } else
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
    }

    
}

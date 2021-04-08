using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    Enemy_Manager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;

    public CapsuleCollider characterCollider;
    public CapsuleCollider characterCollisionBlockerCollider;

    public LayerMask detectionLayer;

    private void Awake()
    {
        enemyManager = GetComponent<Enemy_Manager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
    }

    public void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterCollisionBlockerCollider);
    }
}

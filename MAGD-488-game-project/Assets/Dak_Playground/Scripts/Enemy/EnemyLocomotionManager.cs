using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    Enemy_Manager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;

   

    private void Awake()
    {
        enemyManager = GetComponent<Enemy_Manager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{
    public bool isSleeping;
    public string sleepAnimation;
    public string wakeAnimation;
    public float detectionRadius = 8;
    
    public LayerMask detectionLayer;

    public PursueTargetState pursueTargetState;
  
    public override State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if(isSleeping && enemyManager.isInteracting == false)
        {
            //play sleep anim
            Debug.Log("Is sleeping");
            enemyAnimatorManager.PlayTargetAnimation(sleepAnimation, true);
        }

        #region Handle Target Detection

        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, detectionRadius, detectionLayer);

        for(int i =0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if(characterStats != null)
            {
                Vector3 targetsDirection = characterStats.transform.position - enemyManager.transform.position;
                float viewableAngle = Vector3.Angle(targetsDirection, enemyManager.transform.forward);

                if (viewableAngle > enemyManager.minimumDetectionAngle
                    && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    enemyManager.currentTarget = characterStats;
                    isSleeping = false;

                    //play wake animation
                    Debug.Log("Is awake!");
                    enemyAnimatorManager.PlayTargetAnimation(wakeAnimation, true);
                }
        
            }
        }

        #endregion

        #region Handle State Change 

        if(enemyManager.currentTarget != null)
        {
            return pursueTargetState;
        } else
        {
            return this;
        }
        #endregion
    }
}

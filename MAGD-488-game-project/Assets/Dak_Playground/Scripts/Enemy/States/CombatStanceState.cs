﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStanceState : State
{
    public AttackState attackState;
    public PursueTargetState pursueTargetState;
    public override State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);


        if (enemyManager.isPerformingAction)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        }

        if (enemyManager.currentRecoveryTime <=0 && distanceFromTarget <= enemyManager.maximumAttackRange)
        {
            return attackState;
        } else if(distanceFromTarget > enemyManager.maximumAttackRange)
        {
            return pursueTargetState;
        } else
        {
            return this;
        }
        //potentially circle the player or walk around them
    }
}

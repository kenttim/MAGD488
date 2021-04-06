using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTargetState : State
{
    public override State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //chase the target
        //if within targets range, switch to combat stance state
        //if target is out of range, return this state and continue to chase the target
        return this;
    }

}

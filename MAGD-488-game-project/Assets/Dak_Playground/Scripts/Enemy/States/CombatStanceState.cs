using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStanceState : State
{
    public override State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //check for attack range
        //potentially circle the player or walk around them
        //if in attack range return attack state
        //if we are in a cool down after attacking , return this state and continue circling player
        //if the player runs out of range return the pursue target state
        return this;
    }

   
}

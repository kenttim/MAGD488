using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //select one of our many attacks
        //if the selected attack is not able to be used because of bad angle or distance, select a new attack
        //if the attack is viable, stop our movement and attack the target
        //set our recovery timer to the attacks recovery time
        //return to the combat stance state
        return this;
    }

   
}

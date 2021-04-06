using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract State Tick(Enemy_Manager enemyManager, Enemy_Stats enemyStats, EnemyAnimatorManager enemyAnimatorManager);
}

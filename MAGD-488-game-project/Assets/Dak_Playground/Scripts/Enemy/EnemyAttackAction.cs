﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "A.I/Enemy Actions/Attack Action")]
public class EnemyAttackAction : EnemyActions
{
    public int attackScore = 3;
    public float recoveryTime = 2;

    public float maximumAttackAngle = 35;
    public float minimumAttackAngle = -35;

    public float minimumDistanceNeededToAttack = 8;
    public float maximumDistanceNeededToAttack = 10;
}

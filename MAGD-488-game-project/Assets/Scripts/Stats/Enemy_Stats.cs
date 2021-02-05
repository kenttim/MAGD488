using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : Character_Stats
{
    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : Character_Stats
{
    
   public override void Die()
    {
        base.Die();

        Player_Manager.instance.KillPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : Items
{
    public GameObject spellWarmUpFX;
    public GameObject spellCastFX;
    public string spellAnimation;
        
    public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlotManager)
    {
        Debug.Log("you attempt to cast a spell");
    }

    public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, CameraHandler cameraHandler, WeaponSlotManager weaponSlotManager)
    {
        Debug.Log("You cast a cast");
    }

}

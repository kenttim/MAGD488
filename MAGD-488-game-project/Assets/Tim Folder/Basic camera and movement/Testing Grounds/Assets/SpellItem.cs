using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : Items
{
    public string spellAnimation;
        
    public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler)
    {
        Debug.Log("you attempt to cast a spell");
    }

    public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler)
    {
        Debug.Log("You cast a cast");
    }

}

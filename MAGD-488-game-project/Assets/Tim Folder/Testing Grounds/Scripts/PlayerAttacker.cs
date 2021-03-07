using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimatorHandler animatorHandler;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }

    public void HandleLightMeleeAttack(WeaponItem weapon)
    {
        animatorHandler.PlayTargetAnimation(weapon.L_Attack_1, true);
    }

    public void HandleHeavyMeleeAttack(WeaponItem weapon)
    {
        animatorHandler.PlayTargetAnimation(weapon.H_Attack_1, true);
    }
}

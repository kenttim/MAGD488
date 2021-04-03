using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimatorHandler animatorHandler;
    WeaponSlotManager weaponSlotManager;
    PlayerManager playerManager;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void HandleLightMeleeAttack(WeaponItem weapon)
    {
        if (playerManager.isInteracting)
        {
            return;
        }

        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.L_Attack_1, true);
    }

    public void HandleHeavyMeleeAttack(WeaponItem weapon)
    {
        if (playerManager.isInteracting)
        {
            return;
        }

        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.H_Attack_1, true);
    }
}

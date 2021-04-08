using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimatorHandler animatorHandler;
    WeaponSlotManager weaponSlotManager;
    PlayerManager playerManager;
    InputHandler inputHandler;
    PlayerInventory playerInventory;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        playerManager = GetComponentInParent<PlayerManager>();
        inputHandler = GetComponent<InputHandler>();
        playerInventory = GetComponentInParent<PlayerInventory>();
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

    public void HandleRangeAttack()
    {
        if (playerManager.isInteracting)
        {
            return;
        }
        if (playerInventory.rightWeapon.isRanged)
        {
            PerformMagicAction(playerInventory.rightWeapon);
        }

        //animatorHandler.anim.SetBool("Cast Spell", true);
    }

    private void PerformMagicAction(WeaponItem weapon)
    {
        if (weapon.isRanged)
        {
            
        }
    }
}

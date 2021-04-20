using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    CameraHandler cameraHandler;
    AnimatorHandler animatorHandler;
    WeaponSlotManager weaponSlotManager;
    PlayerManager playerManager;
    InputHandler inputHandler;
    PlayerInventory playerInventory;
    PlayerStats playerStats;
    

    public float projectileSpeed = 10f;

    private void Awake()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        playerManager = GetComponentInParent<PlayerManager>();
        inputHandler = GetComponent<InputHandler>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        playerStats = GetComponentInParent<PlayerStats>();
        
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
            animatorHandler.PlayTargetAnimation("Cast Spell", true);
            
        }

        
    }

    private void PerformRangedAction(GameObject projectile)
    {
        playerInventory.currnetSpell.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);

    }

    private void SuccessfullyShoot()
    {
        playerInventory.currnetSpell.SuccessfullyCastSpell(animatorHandler, playerStats, cameraHandler, weaponSlotManager);
        animatorHandler.anim.SetBool("isFiring", true);
    }
}

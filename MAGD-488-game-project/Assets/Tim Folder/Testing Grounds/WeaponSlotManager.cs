﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    public WeaponItem attackingWeapon;

    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();

        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
                LoadLeftWeaponDamageCollider();
            }
            else if (weaponSlot.isRightHandSlot) 
            {
                rightHandSlot = weaponSlot;
                LoadRightWeaponDamageCollider();
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollider();
        } 
        else {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();
        }
    }

    #region Handle Weapon's Damage Collider
    private void LoadLeftWeaponDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenRightDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }

    public void OpenLeftDamageCollider()
    {
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void CloseRightDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftDamageCollider()
    {
        leftHandDamageCollider.DisableDamageCollider();
    }

    #endregion

    #region Handle Weapon Stamina Drain
    public void DrainStaminaLightAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminaHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }

    #endregion
}

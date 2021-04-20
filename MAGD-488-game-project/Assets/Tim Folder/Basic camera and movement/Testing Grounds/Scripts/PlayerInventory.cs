using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager slotManager;

    public SpellItem currnetSpell;
    public WeaponItem leftWeapon;
    public WeaponItem rightWeapon;

    public List<WeaponItem> weaponsInventory;

    private void Awake()
    {
        slotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        slotManager.LoadWeaponOnSlot(rightWeapon, true);
        slotManager.LoadWeaponOnSlot(leftWeapon, true);
    }
}

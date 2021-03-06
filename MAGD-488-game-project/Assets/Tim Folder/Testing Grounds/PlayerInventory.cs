using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager slotManager;

    public WeaponItem leftWeapon;

    private void Awake()
    {
        slotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        slotManager.LoadWeaponOnSlot(leftWeapon, true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;

    private void Awake()
    {
        WeaponHolderSlot weaponHolderSlot = GetComponentInChildren<WeaponHolderSlot>();
        if(weaponHolderSlot.isLeftHandSlot){
            leftHandSlot = weaponHolderSlot;
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
        }
    }
}

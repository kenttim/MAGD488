﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;

    //added this bc it was missing?
    public WeaponItem currentWeapon;

    public GameObject currentWeaponModel;

    public void UnloadWeapon()
    {
        if(currentWeaponModel != null)
        {
            currentWeaponModel.SetActive(false);
        }
    }

    public void UnloadAndDestroy()
    {
        if(currentWeaponModel != null)
        {
            //Destroy(currentWeaponModel);
        }
    }

    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadAndDestroy();

        if(weaponItem == null)
        {
            UnloadWeapon();
            return;
        }

        GameObject model = Instantiate(weaponItem.modelPrefab);
        if(model != null)
        {
            if(parentOverride != null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }

        currentWeaponModel = model;
    }
}

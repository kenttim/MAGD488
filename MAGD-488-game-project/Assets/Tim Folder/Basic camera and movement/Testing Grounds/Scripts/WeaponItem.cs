using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : Items
{
    public GameObject modelPrefab;
    public bool isUnarmed;
    

    [Header("Melee Attack Animations")]
    public string L_Attack_1;
    public string H_Attack_1;

    [Header("Range Attack Animations")]
    public string R_Attack;

    [Header("Stamina Costs")]
    public int baseStamina;
    public float lightAttackMultiplier;
    public float heavyAttackMultiplier;

    [Header("Weapon Type")]
    public bool isRanged;
    public bool isMelee;
}

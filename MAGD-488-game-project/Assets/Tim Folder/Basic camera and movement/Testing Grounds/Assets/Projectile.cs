using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile")]
public class Projectile : SpellItem
{
    public float baseDamage;
    public float projectileForwardVelocity;
    public float projectileUpwardVelocity;
    public float projectileMass;
    public bool isEffectedByGravity;

    Rigidbody rigidbody;

    public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlotManager)
    {
        base.AttemptToCastSpell(animatorHandler, playerStats, weaponSlotManager);
        GameObject instantiateWarmUpSpellFX = Instantiate(spellWarmUpFX, weaponSlotManager.rightHandSlot.transform);
        //instantiateWarmUpSpellFX.gameObject.transform.localScale = new Vector3(100, 100, 100);
        animatorHandler.PlayTargetAnimation(spellAnimation, true);
    }

    public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, CameraHandler cameraHandler, WeaponSlotManager weaponSlotManager)
    {
        base.SuccessfullyCastSpell(animatorHandler, playerStats, cameraHandler, weaponSlotManager);
        GameObject instantiatedProjectile = Instantiate(spellCastFX, weaponSlotManager.rightHandSlot.transform.position, cameraHandler.cameraPivotTransform.rotation);
        rigidbody = instantiatedProjectile.GetComponent<Rigidbody>();

        if(cameraHandler.currentLockOnTarget != null)
        {
            instantiatedProjectile.transform.LookAt(cameraHandler.currentLockOnTarget.transform);
        } else
        {
            instantiatedProjectile.transform.rotation = Quaternion.Euler(cameraHandler.cameraPivotTransform.eulerAngles.x, playerStats.transform.eulerAngles.y, 0);
        }

        rigidbody.AddForce(instantiatedProjectile.transform.forward * projectileForwardVelocity);
        rigidbody.AddForce(instantiatedProjectile.transform.up * projectileUpwardVelocity);
        rigidbody.useGravity = isEffectedByGravity;
        rigidbody.mass = projectileMass;
        instantiatedProjectile.transform.parent = null;
    }
}

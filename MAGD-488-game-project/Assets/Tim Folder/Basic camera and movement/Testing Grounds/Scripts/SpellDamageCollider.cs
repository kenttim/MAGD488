﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamageCollider : DamageCollider
{
    public GameObject impactParticles;
    public GameObject projectileParticles;
    public GameObject muzzleParticles;

    bool hasCollided = false;

    CharacterStats spellTarget;
    Rigidbody rigidbody;

    Vector3 impactNormal;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        projectileParticles = Instantiate(projectileParticles, transform.position, transform.rotation);
        projectileParticles.transform.parent = transform;

        if (muzzleParticles)
        {
            muzzleParticles = Instantiate(muzzleParticles, transform.position, transform.rotation);
            Destroy(muzzleParticles, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!hasCollided)
        {
            spellTarget = other.transform.GetComponent<CharacterStats>();
            if(spellTarget != null)
            {
                spellTarget.TakeDamage(currentWeaponDamage);
            }

            hasCollided = true;
            impactParticles = Instantiate(impactParticles, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal));
            Destroy(projectileParticles);
            Destroy(impactParticles, 1f);
            Destroy(gameObject, 2f);
        }
    }
}

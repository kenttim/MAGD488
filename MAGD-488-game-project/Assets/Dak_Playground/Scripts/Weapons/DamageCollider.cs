using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;

    public bool enabledDamageColliderOnStartUp = false;

    public int currentWeaponDamage = 25;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = enabledDamageColliderOnStartUp;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log("collided");

        if (collision.tag == "Player")
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            Debug.Log("Hit Player");
            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if (collision.tag == "Boss")
        {
            Enemy_Stats enemyStats = collision.GetComponent<Enemy_Stats>();
            Debug.Log("Hit enemy");
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}

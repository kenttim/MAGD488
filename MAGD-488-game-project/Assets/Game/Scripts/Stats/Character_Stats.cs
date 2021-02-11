using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Stats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor; //armor will be always set at a default unless modified

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //when boss hits character
        //TakeDamage();
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die()
    {
        //die in some way
        Debug.Log(transform.name + " has died.");
    }
}

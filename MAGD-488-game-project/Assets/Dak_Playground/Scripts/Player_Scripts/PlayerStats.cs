using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    HealthBar healthbar;
    StaminaBar staminabar;

    AnimatorHandler animatorHandler;

    private void Awake()
    {
        healthbar = FindObjectOfType<HealthBar>();
        staminabar = FindObjectOfType<StaminaBar>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetCurrentHealth(currentHealth);

        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStamina = maxStamina;
        staminabar.SetMaxStamina(maxStamina);
        staminabar.SetCurrentStamina(currentStamina);
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    private int SetMaxStaminaFromStaminaLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthbar.SetCurrentHealth(currentHealth);

        animatorHandler.PlayTargetAnimation("Take Damage", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Death", true);
            //handle player death
        }
    }

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;

        staminabar.SetCurrentStamina(currentStamina);
    }

    public void StaminaRegen()
    {
        staminaTimer += 1;

       if(currentStamina <= maxStamina && (staminaTimer % 100) == 0)
        {
            currentStamina += 1;
            staminabar.SetCurrentStamina(currentStamina);
            staminaTimer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : CharacterStats
{
    Animator animator;

    public UIEnemyHealthBar enemyHealthBar;

    LevelLoader levelLoader;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public override void TakeDamage(int damage, string damageAnimation = "Take Damage")
    {
        if (isDead)
        {
            levelLoader.VictoryScreen();
        }

        currentHealth = currentHealth - damage;

        enemyHealthBar.SetHealth(currentHealth);

        animator.Play("Take Damage");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Death");
            isDead = true;
            gameObject.SetActive(false);
            levelLoader.VictoryScreen();
            //handle player death
        }
    }
}

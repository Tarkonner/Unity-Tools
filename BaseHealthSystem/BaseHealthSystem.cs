using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthSystem : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 1; 
    public int currentHealth;

    public virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public virtual void Damage(int damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public virtual void Healing(int heal)
    {
        if (currentHealth < maxHealth)
        {
            if (heal + currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += heal;
            }
        }
    }

    public virtual void HealingMax()
    {
        Healing(maxHealth);
    }


    public virtual void Dead()
    {
        Destroy(gameObject);
    }
}

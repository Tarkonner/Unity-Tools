using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseForHealthSystem : MonoBehaviour, ITakeDamage
{
    public HealthFunction health;
    [SerializeField] private int maxHealth = 3;
    
    private void Awake()
    {
       health = new HealthFunction(maxHealth);
    }

    private void OnEnable()
    {
        health.FullHeal();
    }

    protected virtual void Dead()
    {
        gameObject.SetActive(false);
    }

    public virtual void Interaction(int damage) //Damage
    {
        health.TakingDamage(damage);
        
        if(!health.living)
            Dead();
    }
}

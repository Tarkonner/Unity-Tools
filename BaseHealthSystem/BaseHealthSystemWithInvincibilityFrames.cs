using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthSystemWithInvincibilityFrames : BaseHealthSystem
{
    [Header("Invincibility")]
    public bool canTakeDamage = true;
    [SerializeField] private float invincibilityTime = .1f;
    
    
    public override void Damage(int damageTaken)
    {
        if (!canTakeDamage) return;
        
        canTakeDamage = false;
        base.Damage(damageTaken);
        StartCoroutine(InvincibilityFrames());
    }

    private IEnumerator InvincibilityFrames()
    {
        yield return new WaitForSeconds(invincibilityTime);
        canTakeDamage = true;
    }
}

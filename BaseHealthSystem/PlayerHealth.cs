using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealthSystemWithInvincibilityFrames
{
    //Event then taking damage
    public delegate void callTakingDamage();
    public static event callTakingDamage OnDamage;
    
    public override void Damage(int damageTaken)
    {
        base.Damage(damageTaken);
        OnDamage?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisFarmeHealth : BaseForHealthSystem
{
    [SerializeField] private float invulnerabilityFrames = .2f;
    private bool _isInvulnerable;
    
    public override void Interaction(int damage)
    {
        if (!_isInvulnerable)
        {
            StartCoroutine(InvulFrames());
            base.Interaction(damage);
        }
    }

    IEnumerator InvulFrames()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityFrames);
        _isInvulnerable = false;
    }
}

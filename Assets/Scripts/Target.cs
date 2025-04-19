using UnityEngine;

public class Target : Damageable
{
    protected override void OnDefeated()
    {
        base.OnDefeated();
        // Destroy the Target when it runs out of health
        Destroy(gameObject);
    }
}

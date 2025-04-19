using UnityEngine;

public class Target : Damageable
{
    // The Target is destroyed when shot
    public override void OnDamaged()
    {
        Destroy(gameObject);
    }
}

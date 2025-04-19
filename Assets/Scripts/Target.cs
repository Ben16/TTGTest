using UnityEngine;

public class Target : Damageable
{
    public override void OnDamaged()
    {
        Destroy(gameObject);
    }
}

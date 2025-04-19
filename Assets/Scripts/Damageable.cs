using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    // This could be changed to take in damage and have health, if need be
    public abstract void OnDamaged();
}

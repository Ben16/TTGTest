using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    // This could be changed to take in damage and have health, if need be, and then call a separate OnDefeated function
    public abstract void OnDamaged();
}

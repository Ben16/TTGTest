using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public float MaxHealth = 1;
    protected float CurrentHealth;

    public ParticleSystem DamagedParticles;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    protected virtual void OnDamaged(float DamageTaken)
    {
        // Intentionally empty - child classes can define behavior
    }

    public void ReceiveDamage(float Damage)
    {
        // Only take damage if this has health
        if(CurrentHealth > 0.0f)
        {
            CurrentHealth -= Damage;
            OnDamaged(Damage);
            if(CurrentHealth <= 0.0f)
            {
                OnDefeated();
            }
        }
    }
    protected virtual void OnDefeated()
    {
        // Intentionally empty - child classes can define behavior
        // Could make all Damageables Destroy themselves here, if desired
    }
}

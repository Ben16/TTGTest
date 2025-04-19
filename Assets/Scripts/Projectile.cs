using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    protected WeaponWielder Spawner;
    protected float Damage;
    protected IEnumerator DeathTimer;

    private Rigidbody GetCachedRigidbody()
    {
        if(Rigidbody == null)
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
        return Rigidbody;
    }
    public void StartLifetimeTimer(float lifetime)
    {
        DeathTimer = DestroyFromTimeout(lifetime);
        StartCoroutine(DeathTimer);
    }

    IEnumerator DestroyFromTimeout(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    public void SetInitialVelocity(Vector3 velocity)
    {
        GetCachedRigidbody().AddForce(velocity, ForceMode.VelocityChange);
    }

    public void SetSpawner(WeaponWielder spawner)
    {
        Spawner = spawner;
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Don't allow collisions with whomever spawned this projectile
        WeaponWielder shooterScript = collision.transform.GetComponent<WeaponWielder>();
        if(shooterScript != null && shooterScript == Spawner)
        {
            return;
        }

        // If the projectile hits something damageable, damage it
        Damageable damageableCollider = collision.gameObject.GetComponent<Damageable>();
        if(damageableCollider != null)
        {
            //Spawn any fx on hit
            if(damageableCollider.DamagedParticles != null)
            {
                Instantiate(damageableCollider.DamagedParticles, transform.position, transform.rotation);
            }

            damageableCollider.ReceiveDamage(Damage);
        }

        // If the projectile hits anything (regardless of if it's damageable), destroy the projectile
        Destroy(gameObject);
    }
}

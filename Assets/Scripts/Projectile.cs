using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Rigidbody Rigidbody;

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

    }

    public void SetInitialVelocity(Vector3 velocity)
    {
        GetCachedRigidbody().AddForce(velocity, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damageable damageableCollider = collision.gameObject.GetComponent<Damageable>();
        if(damageableCollider != null)
        {
            damageableCollider.OnDamaged();
        }
        Destroy(gameObject);
    }
}

using UnityEngine;

public class WeaponWielder : MonoBehaviour
{
    public Weapon StartingWeapon;
    public MeshFilter WeaponMesh;
    public Transform ProjectileSpawnPoint;
    private Weapon CurrentWeapon;
    
    void Start()
    {
        EquipWeapon(StartingWeapon);
    }

    public void EquipWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
        UpdateWeaponMesh();
    }

    private void UpdateWeaponMesh()
    {
        // Hide the weapon mesh if we have no weapon equipped
        if(CurrentWeapon == null)
        {
            WeaponMesh.mesh = null;
        }
        else
        {
            WeaponMesh.mesh = CurrentWeapon.Mesh;
        }
    }

    public void FireWeapon(Vector3 aimTargetLocation)
    {
        if(CurrentWeapon == null)
        {
            Debug.Log("No weapon equipped");
            return;
        }

        // Create the projectile
        GameObject projectileObject = Instantiate(CurrentWeapon.Projectile, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
        
        // Now that the projecile is spawned, set various fields on it based on how the weapon's set up
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        if(projectile != null)
        {
            projectile.SetSpawner(this);

            // A lifetime <= 0 indicates the projectile should live indefinitely until it hits something
            if(CurrentWeapon.ProjectileLifetime > 0.0f)
            {
                projectile.StartLifetimeTimer(CurrentWeapon.ProjectileLifetime);
            }

            // Point toward the target, with the desired velocity
            Vector3 normalizedDirection = Vector3.Normalize(aimTargetLocation - ProjectileSpawnPoint.position);
            Vector3 projectileInitialVelocity = normalizedDirection * CurrentWeapon.ProjectileLaunchSpeed;
            projectile.SetInitialVelocity(projectileInitialVelocity);
        }
    }
}

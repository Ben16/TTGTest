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

        GameObject projectileObject = Instantiate(CurrentWeapon.Projectile, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
        // restore rotation from prefab
        projectileObject.transform.rotation = CurrentWeapon.Projectile.transform.rotation * transform.rotation;
        
        // Now that the projecile is spawned, set various fields on it based on how the weapon's set up
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        if(projectile != null)
        {
            projectile.SetSpawner(this);

            if(CurrentWeapon.ProjectileLifetime > 0.0f)
            {
                projectile.StartLifetimeTimer(CurrentWeapon.ProjectileLifetime);
            }

            Vector3 normalizedDirection = Vector3.Normalize(aimTargetLocation - ProjectileSpawnPoint.position);
            Vector3 projectileInitialVelocity = normalizedDirection * CurrentWeapon.ProjectileLaunchSpeed;
            projectile.SetInitialVelocity(projectileInitialVelocity);
        }
    }
}

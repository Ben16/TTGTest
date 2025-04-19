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

    public void FireWeapon()
    {
        if(CurrentWeapon == null)
        {
            Debug.Log("No weapon equipped");
            return;
        }

        GameObject projectileObject = Instantiate(CurrentWeapon.Projectile, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
        // restore rotation from prefab
        projectileObject.transform.rotation = CurrentWeapon.Projectile.transform.rotation * transform.rotation;
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        if(projectile != null)
        {
            if(CurrentWeapon.ProjectileLifetime > 0.0f)
            {
                projectile.StartLifetimeTimer(CurrentWeapon.ProjectileLifetime);
            }
            //TODO this need to be based off where the player is looking
            Vector3 projectileInitialVelocity = ProjectileSpawnPoint.forward * CurrentWeapon.ProjectileLaunchSpeed;
            projectile.SetInitialVelocity(projectileInitialVelocity);
        }
    }
}

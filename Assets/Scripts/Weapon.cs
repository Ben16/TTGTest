using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public float ProjectileLaunchSpeed;
    public float ProjectileLifetime;
    public float ProjectileDamage = 1;

    public Mesh Mesh;
    public GameObject Projectile;
}

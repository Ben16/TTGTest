using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public float ProjectileLaunchSpeed;
    public float ProjectileLifetime;
    // Could have more fields, like damage etc
    public Mesh Mesh;
    public GameObject Projectile;
}

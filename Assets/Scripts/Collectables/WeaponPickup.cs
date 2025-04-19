using UnityEngine;

public class WeaponPickup : Collectable
{
    public Weapon Weapon;
    public override void OnCollected(GameObject collector)
    {
        WeaponWielder wielder = collector.GetComponent<WeaponWielder>();
        if(wielder != null)
        {
            // Note: for now, this just overwrites any currently equipped weapon
            wielder.EquipWeapon(Weapon);
        }
        base.OnCollected(collector);
    }

    // Only objects that can wield weapons can pick up weapon pickups
    protected override bool CanInteractWith(GameObject other)
    {
        return other.GetComponent<WeaponWielder>() != null;
    }
}

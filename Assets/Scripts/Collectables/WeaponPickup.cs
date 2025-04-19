using UnityEngine;

public class WeaponPickup : Collectable
{
    public Weapon Weapon;
    public override void OnCollected(GameObject collector)
    {
        WeaponWielder wielder = collector.GetComponent<WeaponWielder>();
        if(wielder != null)
        {
            wielder.EquipWeapon(Weapon);
        }
        base.OnCollected(collector);
    }

    protected override bool CanInteractWith(GameObject other)
    {
        return other.GetComponent<WeaponWielder>() != null;
    }
}

using UnityEngine;

public class Coin : Collectable
{
    public int CoinValue = 1;
    public override void OnCollected(GameObject collector)
    {
        // grant coint
        Inventory inventory = collector.GetComponent<Inventory>();
        if(inventory != null)
        {
            inventory.GainCoins(CoinValue);
        }
        base.OnCollected(collector);
    }

    protected override bool CanInteractWith(GameObject other)
    {
        return other.GetComponent<Inventory>() != null;
    }
}

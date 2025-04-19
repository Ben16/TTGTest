using UnityEngine;

public class Coin : Collectible
{
    public int CoinValue = 1;
    public override void OnCollected(GameObject collector)
    {
        Inventory inventory = collector.GetComponent<Inventory>();
        if(inventory != null)
        {
            inventory.GainCoins(CoinValue);
        }
        base.OnCollected(collector);
    }

    // Only objects with an inventory can pick up coins
    protected override bool CanInteractWith(GameObject other)
    {
        return other.GetComponent<Inventory>() != null;
    }
}

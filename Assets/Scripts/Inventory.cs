using UnityEngine;

public class Inventory : MonoBehaviour
{
    // For now, all we care about are coins
    protected int Coins;

    public delegate void OnCoinsChanged(int CointAmount);
    public OnCoinsChanged CoinsChangedDelegate;

    public void GainCoins(int CoinCount)
    {
        Coins += CoinCount;
        // Notify any listeners (i.e. UI) that the count has changed
        CoinsChangedDelegate.Invoke(Coins);
    }

    public int GetCointCount()
    {
        return Coins;
    }
}

using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public Inventory TrackedInventory;
    public TMPro.TextMeshProUGUI CoinText;
    void Start()
    {
        UpdateCoinCount(TrackedInventory.GetCointCount());
        // Whenever coins count changes, update the UI
        TrackedInventory.CoinsChangedDelegate += UpdateCoinCount;
    }

    private void UpdateCoinCount(int CoinCount)
    {
        CoinText.text = string.Format("Coins: {0}", CoinCount);
    }
}

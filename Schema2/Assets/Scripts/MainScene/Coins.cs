using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    float coins;
    NumberFormatter formatter;
    [SerializeField] TextMeshProUGUI coinsText;
    private void Start()
    {
        formatter = new NumberFormatter();
        ChangeCoins(0);
    }
    public void ChangeCoins(float pAmount)
    {
        coins += pAmount;
        coinsText.text = $"Coins: {formatter.Format(coins)}";
    }
    public bool TrySpendCoins(float pAmount)
    {
        if (coins >= pAmount)
        {
            ChangeCoins(-pAmount);
            return true;
        } else
        {
            return false;
        }
    }
}

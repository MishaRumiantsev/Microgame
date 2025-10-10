using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    float coins;
    [SerializeField] TextMeshProUGUI coinsText;
    private void Start()
    {
        ChangeCoins(0);
    }
    public void ChangeCoins(float pAmount)
    {
        coins += pAmount;
        coinsText.text = $"Coins: {coins}";
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

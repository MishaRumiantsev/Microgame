using System;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    NumberFormatter formatter;
    private void Start()
    {
        formatter = new NumberFormatter();
        coinsText.text = $"Coins: {formatter.FormatNumber(PlayerDataManager.Coins)}";

    }
    public void ChangeCoins(float pAmount)
    {
        PlayerDataManager.Coins += Convert.ToInt32(pAmount);
        coinsText.text = $"Coins: {formatter.FormatNumber(PlayerDataManager.Coins)}";
    }
    public bool TrySpendCoins(float pAmount)
    {
        if (PlayerDataManager.Coins >= pAmount)
        {
            ChangeCoins(-pAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GiveCoins(float pAmount)
    {
        ChangeCoins(100000);
    }
}

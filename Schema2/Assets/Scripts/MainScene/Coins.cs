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
    public void ChangeCoins(double pAmount)
    {
        PlayerDataManager.Coins += Convert.ToInt64(pAmount);

        if (pAmount > 0)
        {
            PlayerDataManager.totalCoins += Convert.ToInt64(pAmount);
        }
        coinsText.text = $"Coins: {formatter.FormatNumber(PlayerDataManager.Coins)}";
    }
    public bool TrySpendCoins(double pAmount)
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
        ChangeCoins(pAmount);
    }
}

using System;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    private void Update()
    {
        ChangeCoins(0);
    }
    public void ChangeCoins(float pAmount)
    {
        int intAmount = Convert.ToInt32(pAmount);
        if (intAmount > 0)
        {
            PlayerDataManager.Coins += intAmount;
            PlayerDataManager.totalCoins += intAmount;
        }
        else if (intAmount < 0)
        {
            PlayerDataManager.Coins += intAmount;
            // Do not change totalCoins when spending
        }
        
        coinsText.text = $"Coins: {PlayerDataManager.Coins}";
    }
    public bool TrySpendCoins(float pAmount)
    {
        if (PlayerDataManager.Coins >= pAmount)
        {
            ChangeCoins(-pAmount);
            return true;
        } else
        {
            return false;
        }
    }

    public void GiveCoins(float pAmount)
    {
        ChangeCoins(100000);
    }
}

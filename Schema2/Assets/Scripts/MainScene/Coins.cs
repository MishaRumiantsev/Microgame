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
        PlayerDataManager.Coins += Convert.ToInt32(pAmount);
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

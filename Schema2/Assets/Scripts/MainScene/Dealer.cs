using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    NumberFormatter formatter;
    public Coins coins;
    int dealerPrice;
    bool hasDealer;

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;


    public void BuyDealer()
    {
        if (coins.TrySpendCoins(dealerPrice))
        {
            hasDealer = true;
            locked.SetActive(false);
        }
    }

    public void SetUpDealer(int pDealerPrice, bool pHasDealer, Coins pCoins)
    {
        formatter = new NumberFormatter();
        coins = pCoins;

        hasDealer = pHasDealer;
        dealerPrice = pDealerPrice;

        if (hasDealer)
        {
            locked.SetActive(false);
        }
        else
        {
            priceText.text = formatter.FormatNumber(dealerPrice).ToString();
        }
    }
}

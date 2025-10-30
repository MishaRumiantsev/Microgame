using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    NumberFormatter formatter;
    Coins coins;
    int dealerPrice;
    int index;
    bool hasDealer;
    

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;
    [SerializeField] GameObject picLocked;
    [SerializeField] GameObject picUnlocked;

    private void Start()
    {
        coins = FindFirstObjectByType<Coins>();
    }

    public void BuyDealer()
    {
        if (coins.TrySpendCoins(dealerPrice))
        {
            hasDealer = true;
            locked.SetActive(false);
            picLocked.SetActive(false);
            gameObject.GetComponentInParent<DealerManager>().dealerBuilding[index] = true;
        }
    }
    public void SetUpDealer(int pIndex, int pDealerPrice, bool pHasDealer, Coins pCoins)
    {
        formatter = new NumberFormatter();
        coins = pCoins;

        index = pIndex;
        hasDealer = pHasDealer;
        dealerPrice = pDealerPrice;

        if (hasDealer)
        {
            locked.SetActive(false);
            picLocked.SetActive(false);
        }
        else
        {
            priceText.text = formatter.FormatNumber(dealerPrice).ToString();
        }
    }

}

using System.Collections.Generic;
using UnityEngine;

public class DealerManager : MonoBehaviour
{
    public List<GameObject> dealers;
    List<int> dealerPrice = new List<int>() { 100, 725, 2856, 12418, 46039, 170436, 540606, 2333718, 7401275, 8401275 };
    Coins coins;

    void Start()
    {
        coins = FindFirstObjectByType<Coins>();

        for (int i = 0; i < dealers.Count; i++)
        {
            Dealer dealer = dealers[i].GetComponent<Dealer>();

            dealer.SetUpDealer(dealerPrice[i], false, coins);

            //if (i == 0)
            //{
            //    dealer.SetUpDealer(dealerPrice[i], true, coins);
            //}
            //else
            //{
            //    dealer.SetUpDealer(dealerPrice[i], false, coins);
            //}
        }
    }

}

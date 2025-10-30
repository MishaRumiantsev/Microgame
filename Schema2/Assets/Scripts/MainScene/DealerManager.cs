using System.Collections.Generic;
using UnityEngine;

public class DealerManager : MonoBehaviour
{
    public List<GameObject> dealers;
    List<int> dealerPrice = new List<int>() { 100, 725, 2856, 12418, 46039, 170436, 540606, 2333718, 7401275, 8401275 };
    public List<bool> dealerBuilding;
    Coins coins;

    void Start()
    {
        coins = FindFirstObjectByType<Coins>();

        switch (FindFirstObjectByType<SceneChecker>().buildingNumber)
        {
            case 0:
                dealerBuilding = PlayerDataManager.Instance.playerData.building0Dealers;
                break;
            case 1:
                dealerBuilding = PlayerDataManager.Instance.playerData.building1Dealers;
                break;
            case 2:
                dealerBuilding = PlayerDataManager.Instance.playerData.building2Dealers;
                break;
            case 3:
                dealerBuilding = PlayerDataManager.Instance.playerData.building3Dealers;
                break;
        }

        for (int i = 0; i < dealers.Count; i++)
        {
            Dealer dealer = dealers[i].GetComponent<Dealer>();

            dealer.SetUpDealer(i, dealerPrice[i], dealerBuilding[i], coins);
        }
    }
}

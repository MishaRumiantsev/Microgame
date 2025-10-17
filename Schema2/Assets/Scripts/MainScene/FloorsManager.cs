using System.Collections.Generic;
using UnityEngine;

public class FloorsManager : MonoBehaviour
{
    public List<FloorManager> floors;
    List<int> floorIncomes = new List<int>() { 9, 27, 125, 476, 1774, 6577, 24348, 90101, 333387, 1233545 };
    List<int> floorPrices = new List<int>() { 0, 100, 725, 2856, 12418, 46039, 170436, 540606, 2333718, 7401275 };
    List<float> floorDurations = new List<float> { 5.3f, 6.8f, 12.1f, 23.5f, 34.8f, 69.2f, 105.7f, 198.3f, 312.6f, 560.4f };
    List<int> floorUpgradePrices = new List<int>() { 23, 61, 469, 1685, 7700, 31253, 107984, 323556, 1542058, 4954509 };
    [SerializeField] Coins coins;


    void Start()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            if (i == 0)
            {
                floors[i].SetUpFloor(0, floorIncomes[i], floorPrices[i], floorUpgradePrices[i], floorDurations[i], true, coins);
            }
            else
            {
                floors[i].SetUpFloor(0, floorIncomes[i], floorPrices[i], floorUpgradePrices[i], floorDurations[i], false, coins);
            }
        }
    }
}

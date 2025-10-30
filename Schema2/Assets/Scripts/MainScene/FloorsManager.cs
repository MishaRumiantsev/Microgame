using System.Collections.Generic;
using UnityEngine;

public class FloorsManager : MonoBehaviour
{
    public List<GameObject> floors;
    List<int> floorIncomes = new List<int>() { 9, 27, 125, 476, 1774, 6577, 24348, 90101, 333387, 1233545 };
    List<int> floorPrices = new List<int>() { 0, 100, 725, 2856, 12418, 46039, 170436, 540606, 2333718, 7401275 };
    List<float> floorDurations = new List<float> { 5.3f, 6.8f, 12.1f, 23.5f, 34.8f, 69.2f, 105.7f, 198.3f, 312.6f, 560.4f };
    List<int> floorUpgradePrices = new List<int>() { 23, 61, 469, 1685, 7700, 31253, 107984, 323556, 1542058, 4954509 };

    public List<bool> buildingFloor;
    public List<int> buildingUpgrades;
    public List<int> buildingResources;
    public List<double> buildingPassiveIncome;
    public List<bool> dealerBuilding;

    Coins coins;


    void Start()
    {
        coins = FindFirstObjectByType<Coins>();

        switch (FindFirstObjectByType<SceneChecker>().buildingNumber)
        {
            case 0:
                buildingFloor = PlayerDataManager.Instance.playerData.building0Floors;
                buildingUpgrades = PlayerDataManager.Instance.playerData.building0Upgrades;
                buildingResources = PlayerDataManager.Instance.playerData.building0Resources;
                buildingPassiveIncome = PlayerDataManager.Instance.playerData.building0PassiveIncome;
                dealerBuilding = PlayerDataManager.Instance.playerData.building0Dealers;
                break;
            case 1:
                buildingFloor = PlayerDataManager.Instance.playerData.building1Floors;
                buildingUpgrades = PlayerDataManager.Instance.playerData.building1Upgrades;
                buildingResources = PlayerDataManager.Instance.playerData.building1Resources;
                buildingPassiveIncome = PlayerDataManager.Instance.playerData.building1PassiveIncome;
                dealerBuilding = PlayerDataManager.Instance.playerData.building1Dealers;
                break;
            case 2:
                buildingFloor = PlayerDataManager.Instance.playerData.building2Floors;
                buildingUpgrades = PlayerDataManager.Instance.playerData.building2Upgrades;
                buildingResources = PlayerDataManager.Instance.playerData.building2Resources;
                buildingPassiveIncome = PlayerDataManager.Instance.playerData.building2PassiveIncome;
                dealerBuilding = PlayerDataManager.Instance.playerData.building2Dealers;
                break;
            case 3:
                buildingFloor = PlayerDataManager.Instance.playerData.building3Floors;
                buildingUpgrades = PlayerDataManager.Instance.playerData.building3Upgrades;
                buildingResources = PlayerDataManager.Instance.playerData.building3Resources;
                buildingPassiveIncome = PlayerDataManager.Instance.playerData.building3PassiveIncome;
                dealerBuilding = PlayerDataManager.Instance.playerData.building3Dealers;
                break;
        }
        
        for (int i = 0; i < floors.Count; i++)
        {
            FloorManager floor = floors[i].GetComponent<FloorManager>();

            floor.SetUpFloor(i, buildingUpgrades[i], buildingResources[i], floorIncomes[i], floorPrices[i], floorUpgradePrices[i], floorDurations[i], buildingFloor[i], coins);
        }
    }
    public void SavePassiveIncomeOfBuilding()
    {
        if (PlayerDataManager.Instance.playerData.elevatorUpgrades[FindFirstObjectByType<SceneChecker>().buildingNumber] >= 5)
        {
            for (int i = 0; i < floors.Count; i++)
            {
                FloorManager floor = floors[i].GetComponent<FloorManager>();
                buildingPassiveIncome[i] = floor.GetPassiveIncome();
            }
        }
    }
}

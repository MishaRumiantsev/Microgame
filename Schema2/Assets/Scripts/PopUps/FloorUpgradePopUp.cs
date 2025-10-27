using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorUpgradePopUp : MonoBehaviour
{
    public int index;
    FloorUpgrade floorUpgrade;
    FloorManager floor;
    NumberFormatter formatter;

    [SerializeField] TextMeshProUGUI incomeText;
    [SerializeField] TextMeshProUGUI cycleText;
    [SerializeField] TextMeshProUGUI capacityText;
    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] TextMeshProUGUI priceText;

    [SerializeField] Button upgradeButton;
    [SerializeField] List<Toggle> toggles;

    private void Start()
    {
        formatter = new NumberFormatter();

        FloorsManager floorsManager = FindFirstObjectByType<FloorsManager>();
        floor = floorsManager.floors[index].GetComponent<FloorManager>();
        floorUpgrade = floorsManager.floors[index].GetComponent<FloorUpgrade>();

        UpdateWindow();
    }
    private void Update()
    {
        if (upgradeButton.interactable != floorUpgrade.enoughCoins)
        {
            upgradeButton.interactable = floorUpgrade.enoughCoins;
        }
    }
    public void LevelUp()
    {
        floorUpgrade.LevelUp();
        UpdateWindow();
    }
    public void SetMultiplier(int multiplier)
    {
        int toggleIndex = 0;
        switch (multiplier) 
        { 
            case 1:
                toggleIndex = 0; 
                break;
            case 10:
                toggleIndex = 1; 
                break;
            case 50:
                toggleIndex = 2;
                break;
            case -1:
                toggleIndex = 3;
                break;
        }
        if (toggles[toggleIndex].isOn)
        {
            floorUpgrade.SetMultiplier(multiplier);
            priceText.text = formatter.FormatNumber(floorUpgrade.totalPrice);
            upgradeText.text = $"Upgrade x{floorUpgrade.levelsToUpgrade}";
        }
    }
    public void UpdateWindow()
    {
        incomeText.text = formatter.FormatNumber(floor.income);
        cycleText.text = formatter.FormatNumber(floor.duration);
        capacityText.text = formatter.FormatNumber(floor.maxResources);
        levelText.text = formatter.FormatNumber(floorUpgrade.level + 1);
        priceText.text = formatter.FormatNumber(floorUpgrade.totalPrice);
        upgradeText.text = $"Upgrade x{floorUpgrade.levelsToUpgrade}";
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

        PointerEventData pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(toggles[GetToggleIndex(floorUpgrade.upgradeMultiplier)].gameObject, pointer, ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(toggles[GetToggleIndex(floorUpgrade.upgradeMultiplier)].gameObject, pointer, ExecuteEvents.pointerUpHandler);

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
        if (floorUpgrade != null)
        {
            int toggleIndex = GetToggleIndex(multiplier);
            if (toggles[toggleIndex].isOn)
            {
                floorUpgrade.SetMultiplier(multiplier);
                priceText.text = formatter.FormatNumber(floorUpgrade.totalPrice);
                upgradeText.text = $"Upgrade x{floorUpgrade.levelsToUpgrade}";
            }
        }
    }
    int GetToggleIndex(int pMultiplier)
    {
        switch (pMultiplier)
        {
            case 1:
                return 0;
            case 10:
                return 1;
            case 50:
                return 2;
            case -1:
                return 3;
        }
        return 0;
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

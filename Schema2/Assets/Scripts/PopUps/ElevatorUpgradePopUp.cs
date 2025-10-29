
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElevatorUpgradePopUp : MonoBehaviour
{
    Elevator elevator;
    ElevatorUpgrade elevatorUpgrade;
    NumberFormatter formatter;

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] TextMeshProUGUI loadTimeText;
    [SerializeField] TextMeshProUGUI maxLoadText;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI upgradeText;

    [SerializeField] List<Toggle> toggles;
    [SerializeField] Button upgradeButton;
    private void Start()
    {
        formatter = new NumberFormatter();

        elevator = FindFirstObjectByType<Elevator>();
        elevatorUpgrade = FindFirstObjectByType<ElevatorUpgrade>();

        PointerEventData pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(toggles[GetToggleIndex(elevatorUpgrade.upgradeMultiplier)].gameObject, pointer, ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(toggles[GetToggleIndex(elevatorUpgrade.upgradeMultiplier)].gameObject, pointer, ExecuteEvents.pointerUpHandler);

        UpdateWindow();
    }
    private void Update()
    {
        if (upgradeButton.interactable != elevatorUpgrade.enoughCoins)
        {
            upgradeButton.interactable = elevatorUpgrade.enoughCoins;
        }
    }
    public void SetMultiplier(int multiplier)
    {
        if (elevatorUpgrade != null)
        {
            int toggleIndex = GetToggleIndex(multiplier);
            if (toggles[toggleIndex].isOn)
            {
                elevatorUpgrade.SetMultiplier(multiplier);
                priceText.text = formatter.FormatNumber(elevatorUpgrade.totalPrice);
                upgradeText.text = $"Upgrade x{elevatorUpgrade.levelsToUpgrade}";
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
    public void LevelUp()
    {
        elevatorUpgrade.LevelUp();
        UpdateWindow();
    }
    void UpdateWindow()
    {
        priceText.text = formatter.FormatNumber(elevatorUpgrade.totalPrice);
        upgradeText.text = $"Upgrade x{elevatorUpgrade.levelsToUpgrade}";
        levelText.text = formatter.FormatNumber(elevatorUpgrade.level + 1);
        loadTimeText.text = formatter.FormatTime(elevator.loadTime);
        maxLoadText.text = formatter.FormatNumber(elevator.maxLoad);
    }
}

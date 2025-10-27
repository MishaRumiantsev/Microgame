
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
            elevatorUpgrade.SetMultiplier(multiplier);
            priceText.text = formatter.FormatNumber(elevatorUpgrade.totalPrice);
            upgradeText.text = $"Upgrade x{elevatorUpgrade.levelsToUpgrade}";
        }
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

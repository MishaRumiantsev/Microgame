using TMPro;
using UnityEngine;

public class FloorUpgradePopUp : MonoBehaviour
{
    public FloorUpgrade floorUpgrade;
    public FloorManager floor;
    NumberFormatter formatter;

    [SerializeField] TextMeshProUGUI incomeText;
    [SerializeField] TextMeshProUGUI cycleText;
    [SerializeField] TextMeshProUGUI capacityText;
    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] TextMeshProUGUI priceText;
    private void Start()
    {
        formatter = new NumberFormatter();
        UpdateWindow();
    }
    public void LevelUp()
    {
        floorUpgrade.LevelUp();
        UpdateWindow();
    }
    public void SetMultiplier(int multiplier)
    {
        floorUpgrade.SetMultiplier(multiplier);
        priceText.text = formatter.FormatNumber(floorUpgrade.totalPrice);
        upgradeText.text = $"Upgrade x{floorUpgrade.levelsToUpgrade}";
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

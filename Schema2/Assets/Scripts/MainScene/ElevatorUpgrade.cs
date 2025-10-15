using TMPro;
using UnityEngine;

public class ElevatorUpgrade : MonoBehaviour
{
    Elevator elevator;

    int level;
    [SerializeField] TextMeshProUGUI levelText;

    int basisMaxLoad;
    float maxLoadIncreaseFactor;

    int upgradeMultiplier;
    int levelsToUpgrade;

    int basisPrice;
    float priceIncreaseFactor;
    float totalPrice;

    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] TextMeshProUGUI loadTimeText;
    [SerializeField] TextMeshProUGUI maxLoadText;
    [SerializeField] TextMeshProUGUI levelTextInUpgradeWindow;
    [SerializeField] GameObject upgradeWindow;

    NumberFormatter formatter;
    [SerializeField] Coins coins;

    void Start()
    {
        elevator = GetComponent<Elevator>();
        formatter = new NumberFormatter();

        level = 0;
        levelText.text = $"Level: {formatter.FormatNumber(level + 1)}";
        levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);

        maxLoadIncreaseFactor = 1.2f;
        basisMaxLoad = 100;

        priceIncreaseFactor = 1.2f;
        basisPrice = 150;

        loadTimeText.text = formatter.FormatTime(elevator.loadTime);

        CalculateMaxLoad();
        SetMultiplier(1);
    }

    public void OpenWindow()
    {
        upgradeWindow.SetActive(true);
    }
    public void CloseWindow()
    {
        upgradeWindow.SetActive(false);

    }
    public void SetMultiplier(int pUpgradeMultiplier)
    {
        upgradeMultiplier = pUpgradeMultiplier;

        levelsToUpgrade = upgradeMultiplier;
        if (upgradeMultiplier == -1)
        {
            float nextLevelPrice = basisPrice * Mathf.Pow(priceIncreaseFactor, level);
            levelsToUpgrade = Mathf.FloorToInt(Mathf.Log(1 + PlayerDataManager.Coins * (priceIncreaseFactor - 1) / nextLevelPrice, priceIncreaseFactor));
        }
        CalculateTotalPrice();
    }
    void CalculateTotalPrice()
    {
        float nextLevelPrice = basisPrice * Mathf.Pow(priceIncreaseFactor, level);
        totalPrice = nextLevelPrice * (Mathf.Pow(priceIncreaseFactor, levelsToUpgrade) - 1) / (priceIncreaseFactor - 1);
        priceText.text = formatter.FormatNumber(totalPrice);
    }
    void CalculateMaxLoad()
    {
        elevator.maxLoad = basisMaxLoad * Mathf.Pow(maxLoadIncreaseFactor, level);
        maxLoadText.text = formatter.FormatNumber(elevator.maxLoad);
    }
    public void LevelUp()
    {
        if (coins.TrySpendCoins(totalPrice))
        {
            level += levelsToUpgrade;
            levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);

            SetMultiplier(upgradeMultiplier);
            CalculateMaxLoad();

            levelText.text = $"Level: {formatter.FormatNumber(level + 1)}";
            levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);
        }
    }
}


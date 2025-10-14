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
        levelText.text = $"Level: {formatter.Format(level + 1)}";

        maxLoadIncreaseFactor = 1.2f;
        basisMaxLoad = 100;

        priceIncreaseFactor = 1.4f;
        basisPrice = 300;

        CalculateMaxLoad();
        SetMultieplier(1);
    }

    void CalculateMaxLoad()
    {
        elevator.maxLoad = basisMaxLoad * Mathf.Pow(maxLoadIncreaseFactor, level);
    }

    public void OpenUpgradeWindow()
    {
        UpdateUpgradeWindow();
        upgradeWindow.SetActive(true);
    }
    public void CloseUpgradeWindow()
    {
        upgradeWindow.SetActive(false);

    }
    void UpdateUpgradeWindow()
    {
        levelTextInUpgradeWindow.text = formatter.Format(level + 1);
        maxLoadText.text = formatter.Format(elevator.maxLoad);
        loadTimeText.text = $"{elevator.loadTime}s";
    }
    public void SetMultieplier(int pUpgradeMultiplier)
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
        priceText.text = formatter.Format(totalPrice);
    }
    public void LevelUp()
    {
        if (coins.TrySpendCoins(totalPrice))
        {
            level += levelsToUpgrade;

            SetMultieplier(upgradeMultiplier);
            CalculateMaxLoad();

            levelText.text = $"Level: {formatter.Format(level + 1)}";
            UpdateUpgradeWindow();
        }
    }
}


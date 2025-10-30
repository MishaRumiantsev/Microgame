using TMPro;
using UnityEngine;

public class ElevatorUpgrade : MonoBehaviour
{
    Elevator elevator;

    public int level;
    [SerializeField] TextMeshProUGUI levelText;

    int basisMaxLoad;
    float maxLoadIncreaseFactor;

    public int upgradeMultiplier;
    public int levelsToUpgrade;

    int basisPrice;
    float priceIncreaseFactor;
    public double totalPrice;

    public bool enoughCoins;

    NumberFormatter formatter;
    [SerializeField] Coins coins;

    void Start()
    {
        elevator = GetComponent<Elevator>();
        formatter = new NumberFormatter();

        level = 0;
        levelText.text = $"Level: {formatter.FormatNumber(level + 1)}";

        maxLoadIncreaseFactor = 1.2f;
        basisMaxLoad = 100;

        priceIncreaseFactor = 1.2f;
        basisPrice = 150;

        CalculateMaxLoad();
        SetMultiplier(1);
    }
    private void Update()
    {
        if (!enoughCoins && totalPrice <= PlayerDataManager.Coins)
        {
            enoughCoins = true;
        }
    }
    public void SetMultiplier(int pUpgradeMultiplier)
    {
        upgradeMultiplier = pUpgradeMultiplier;

        levelsToUpgrade = upgradeMultiplier;
        if (upgradeMultiplier == -1)
        {
            float nextLevelPrice = basisPrice * Mathf.Pow(priceIncreaseFactor, level);
            levelsToUpgrade = Mathf.FloorToInt(Mathf.Log(1 + PlayerDataManager.Coins * (priceIncreaseFactor - 1) / nextLevelPrice, priceIncreaseFactor));
            while (levelsToUpgrade > 1)
            {
                totalPrice = nextLevelPrice * (Mathf.Pow(priceIncreaseFactor, levelsToUpgrade) - 1) / (priceIncreaseFactor - 1);
                if (totalPrice <= PlayerDataManager.Coins)
                {
                    break;
                }
                levelsToUpgrade--;
            }
            if (levelsToUpgrade <= 0)
            {
                levelsToUpgrade = 1;
            }
        }
        CalculateTotalPrice();
    }
    void CalculateTotalPrice()
    {
        float nextLevelPrice = basisPrice * Mathf.Pow(priceIncreaseFactor, level);
        totalPrice = nextLevelPrice * (Mathf.Pow(priceIncreaseFactor, levelsToUpgrade) - 1) / (priceIncreaseFactor - 1);
        enoughCoins = PlayerDataManager.Coins >= totalPrice;
    }
    void CalculateMaxLoad()
    {
        elevator.maxLoad = basisMaxLoad * Mathf.Pow(maxLoadIncreaseFactor, level);
    }
    public void LevelUp()
    {
        if (coins.TrySpendCoins(totalPrice))
        {
            level += levelsToUpgrade;

            SetMultiplier(upgradeMultiplier);
            CalculateMaxLoad();

            levelText.text = $"Level: {formatter.FormatNumber(level + 1)}";
        }
    }
}


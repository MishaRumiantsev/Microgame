using TMPro;
using UnityEngine;

public class FloorUpgrade : MonoBehaviour
{
    int basisIncome;
    int basisMaxResources;
    float basisDuration;

    float incomeIncreaseFactor;
    float maxResourcesIncreaseFactor;
    float durationIncreaseFactor;

    int basisPrice;
    public float totalPrice;
    float priceIncreaseFactor;

    public int level;
    public int levelsToUpgrade;
    int upgradeMultiplier;
    [SerializeField] TextMeshProUGUI levelText;

    NumberFormatter formatter;
    FloorManager floor;


    public void UpdateStats(int pLevel, int pBasisIncome, int pBasisPrice, float pBasisDuration)
    {
        formatter = new NumberFormatter();

        basisIncome = pBasisIncome;
        incomeIncreaseFactor = 1.2f;

        basisMaxResources = pBasisIncome * 5;
        maxResourcesIncreaseFactor = 1.2f;
        
        basisDuration = pBasisDuration;
        durationIncreaseFactor = 0.95f;
        
        basisPrice = pBasisPrice;
        priceIncreaseFactor = 1.22f;

        level = pLevel;
        levelText.text = formatter.FormatNumber(level + 1);

        floor = GetComponent<FloorManager>();

        CalculateIncome();
        CalculateMaxResources();
        CalculateDuration();
        SetMultiplier(1);
    }
    void CalculateIncome()
    {
        floor.income = basisIncome * Mathf.Pow(incomeIncreaseFactor, level);
    }
    void CalculateMaxResources()
    {
        floor.maxResources = basisMaxResources * Mathf.Pow(maxResourcesIncreaseFactor, level);
    }
    void CalculateDuration()
    {
        floor.duration = basisDuration * Mathf.Pow(durationIncreaseFactor, level);
    }
    public void SetMultiplier(int pMulitplier)
    {
        upgradeMultiplier = pMulitplier;
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
    }
    public void LevelUp()
    {
        if (floor.coins.TrySpendCoins(totalPrice))
        {
            level += levelsToUpgrade;

            SetMultiplier(upgradeMultiplier);
            CalculateIncome();
            CalculateMaxResources();
            CalculateDuration();

            levelText.text = formatter.FormatNumber(level + 1);
        }
    }

}

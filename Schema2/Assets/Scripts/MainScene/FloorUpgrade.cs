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
    float totalPrice;
    float priceIncreaseFactor;

    int level;
    int levelsToUpgrade;
    int upgradeMultiplier;
    [SerializeField] TextMeshProUGUI levelText;

    NumberFormatter formatter;
    FloorManager floor;

    int siblingIndex;
    [SerializeField] Transform floorContainer;

    [SerializeField] GameObject upgradeWindow;
    [SerializeField] TextMeshProUGUI levelTextInUpgradeWindow;
    [SerializeField] TextMeshProUGUI incomeTextInUpgradeWindow;
    [SerializeField] TextMeshProUGUI durationTextInUpgradeWindow;
    [SerializeField] TextMeshProUGUI maxResourcesTextInUpgradeWindow;
    [SerializeField] TextMeshProUGUI priceText;



    public void UpdateStats(int pLevel, int pBasisIncome, int pBasisPrice, float pBasisDuration)
    {
        formatter = new NumberFormatter();

        int siblingIndex = floorContainer.GetSiblingIndex();

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
        levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);

        floor = GetComponent<FloorManager>();

        CalculateIncome();
        CalculateMaxResources();
        CalculateDuration();
        SetMultiplier(1);
    }
    void CalculateIncome()
    {
        floor.income = basisIncome * Mathf.Pow(incomeIncreaseFactor, level);
        incomeTextInUpgradeWindow.text = formatter.FormatNumber(floor.income);
    }
    void CalculateMaxResources()
    {
        floor.maxResources = basisMaxResources * Mathf.Pow(maxResourcesIncreaseFactor, level);
        maxResourcesTextInUpgradeWindow.text = formatter.FormatNumber(floor.maxResources);
    }
    void CalculateDuration()
    {
        floor.duration = basisDuration * Mathf.Pow(durationIncreaseFactor, level);
        durationTextInUpgradeWindow.text = formatter.FormatTime(floor.duration);
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
        priceText.text = formatter.FormatNumber(totalPrice);
    }
    public void LevelUp()
    {
        if (floor.coins.TrySpendCoins(totalPrice))
        {
            level += levelsToUpgrade;
            levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);

            SetMultiplier(upgradeMultiplier);
            CalculateIncome();
            CalculateMaxResources();
            CalculateDuration();

            levelText.text = formatter.FormatNumber(level + 1);
            levelTextInUpgradeWindow.text = formatter.FormatNumber(level + 1);
        }
    }
    public void OpenWindow()
    {
        floorContainer.SetAsLastSibling();
        upgradeWindow.SetActive(true);
    }
    public void CloseWindow()
    {
        floorContainer.SetSiblingIndex(siblingIndex);
        upgradeWindow.SetActive(false);
    }

}

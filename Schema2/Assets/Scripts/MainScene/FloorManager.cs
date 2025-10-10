using TMPro;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    // variabelen voor het beheren van inkomen
    int basisIncome;
    float currentIncome;
    float incomeIncreaseFactor;

    // variabelen voor het beheren van hoevelheid van resources in verdieping
    int basisMaxResources;
    float currentMaxResources;
    float maxResourcesIncreaseFactor;
    public float currentResources;
    bool currentResourcesChanged;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    // variabelen voor het beheren van upgrade system
    int level;
    int basisUpgradePrice;
    float currentUpgradePrice;
    float upgradePriceIncreaseFactor;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI currentPriceUpgradeText;

    // variabelen voor het beheren van de duur van de productie
    float basisDuration;
    float duration;
    float durationIncreaseFactor;
    Timer timer;

    // variabelen voor het beheren van de duur van de verdieping
    int floorPrice;
    bool isUnlocked;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;

    NumberFormatter formatter;
    [SerializeField] Coins coins;
    [SerializeField] TextMeshProUGUI status;


    private void Start()
    {
        formatter = new NumberFormatter();

        incomeIncreaseFactor = 1.2f;
        durationIncreaseFactor = 0.95f;
        maxResourcesIncreaseFactor = 1.5f;
        upgradePriceIncreaseFactor = 1.5f;

        timer = GetComponent<Timer>();
        timer.OnTimerComplete += AddToCurrentResources;


        ChangeCurrentResources(0);
    }
    private void Update()
    {
        if (timer.isRunning)
        {
            UpdateProgressBar();
        }
        else if (status.text != "inactive")
        {
            status.text = "inactive";
        }
        if (currentResourcesChanged)
        {
            currentResourcesText.text = formatter.Format(currentResources);
            currentResourcesChanged = false;
        }
    }

    public void OnClick()
    {
        if (!timer.isRunning)
        {
            timer.StartTimer(duration);
        }
    }
    /// <summary>
    /// Verhoogt level van de verdieping als speler genoeg coins heeft
    /// </summary>
    public void LevelUp()
    {
        if (coins.TrySpendCoins(currentUpgradePrice))
        {
            level++;
            levelText.text = level.ToString();
            CalculateDuration();
            CalculateIncome();
            CalculateMaxResources();
            CalculateUpgradePrice();
        }
    }
    /// <summary>
    /// Wijzigt de hoeveelheeid resources op verdieping 
    /// </summary>
    public void ChangeCurrentResources(float pAmount)
    {
        currentResources += pAmount;
        if (currentResources > currentMaxResources)
        {
            currentResources = currentMaxResources;
        }
        currentResourcesChanged = true;
    }
    void UpdateProgressBar()
    {
        status.text = $"Working {timer.timeRemainingPercentage}%";
    }
    void AddToCurrentResources()
    {
        ChangeCurrentResources(currentIncome);
    }
    public void BuyFloor()
    {
        if (coins.TrySpendCoins(floorPrice))
        {
            isUnlocked = true;
            locked.SetActive(false);
        }
    }
    public void SetUpFloor(int pLevel, int pBasisIncome, int pFloorPrice, int pBasisUpgradePrice, float pBasisDuration, bool pIsUnlocked)
    {
        isUnlocked = pIsUnlocked;
        floorPrice = pFloorPrice;

        if (isUnlocked)
        {
            locked.SetActive(false);
        }
        else
        {
            priceText.text = floorPrice.ToString();
        }

        level = pLevel;
        levelText.text = level.ToString();

        basisUpgradePrice = pBasisUpgradePrice;
        basisIncome = pBasisIncome;
        basisDuration = pBasisDuration;

        basisMaxResources = pBasisIncome * 5;

        currentResources = 0;

        CalculateIncome();
        CalculateDuration();
        CalculateMaxResources();
        CalculateUpgradePrice();
    }
    /// <summary>
    /// berekent currentIncome afhankelijk van level
    /// </summary>
    void CalculateIncome()
    {
        currentIncome = basisIncome * Mathf.Pow(incomeIncreaseFactor, level);
    }
    /// <summary>
    /// berekent duration afhankelijk van level
    /// </summary>
    void CalculateDuration()
    {
        duration = basisDuration * Mathf.Pow(durationIncreaseFactor, level);
    }
    /// <summary>
    /// berekent MaxResources afhankelijk van level
    /// </summary>
    void CalculateMaxResources()
    {
        currentMaxResources = basisMaxResources * Mathf.Pow(maxResourcesIncreaseFactor, level);
    }
    /// <summary>
    /// berekent upgradePrice afhankelijk van level
    /// </summary>
    void CalculateUpgradePrice()
    {
        currentUpgradePrice = basisUpgradePrice * Mathf.Pow(upgradePriceIncreaseFactor, level);
        currentPriceUpgradeText.text = currentUpgradePrice.ToString();
    }
}

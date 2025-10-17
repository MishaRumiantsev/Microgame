using TMPro;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public float income;
    public float maxResources;
    public float duration;


    public float currentResources;
    bool currentResourcesChanged;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    int floorPrice;
    bool isUnlocked;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;

    Timer timer;
    FloorUpgrade upgrader;
    NumberFormatter formatter;
    public Coins coins;
    [SerializeField] TextMeshProUGUI status;

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
            currentResourcesText.text = formatter.FormatNumber(currentResources);
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
    /// Wijzigt de hoeveelheeid resources op verdieping 
    /// </summary>
    public void ChangeCurrentResources(float pAmount)
    {
        currentResources += pAmount;
        if (currentResources > maxResources)
        {
            currentResources = maxResources;
        }
        currentResourcesChanged = true;
    }
    void UpdateProgressBar()
    {
        status.text = $"Working {timer.timeRemainingPercentage}%";
    }
    void AddToCurrentResources()
    {
        ChangeCurrentResources(income);
    }
    public void BuyFloor()
    {
        if (coins.TrySpendCoins(floorPrice))
        {
            isUnlocked = true;
            locked.SetActive(false);
        }
    }
    public void SetUpFloor(int pLevel, int pBasisIncome, int pFloorPrice, int pBasisUpgradePrice, float pBasisDuration, bool pIsUnlocked, Coins pCoins)
    {
        formatter = new NumberFormatter();
        timer = GetComponent<Timer>();
        upgrader = GetComponent<FloorUpgrade>();
        coins = pCoins;
        timer.OnTimerComplete += AddToCurrentResources;

        ChangeCurrentResources(0);

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

        currentResources = 0;

        upgrader.UpdateStats(pLevel, pBasisIncome, pBasisUpgradePrice, pBasisDuration);
    }
}

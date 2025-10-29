using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    public float income;
    public float maxResources;
    public float duration;

    int index;

    public float currentResources;
    bool currentResourcesChanged;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    int floorPrice;
    public bool isUnlocked;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;

    [SerializeField] Image imageStatus;

    Timer timer;
    FloorUpgrade upgrader;
    NumberFormatter formatter;
    public Coins coins;

    FloorsManager floorsManager;

    private void Update()
    {
        if (timer.isRunning)
        {
            UpdateProgressBar();
        }
        else if( imageStatus.fillAmount > 0)
        {
            imageStatus.fillAmount = 0;
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
        else
        {
            float reduction = Mathf.Min(duration * 0.05f, 5f);
            timer.timeRemaining = Mathf.Max(timer.timeRemaining - reduction, 0);
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
        imageStatus.fillAmount = Mathf.MoveTowards(imageStatus.fillAmount, timer.progresPercentage / 100f, Time.deltaTime * 6f);
    }
    void AddToCurrentResources()
    {
        ChangeCurrentResources(income);
    }
    public void BuyFloor()
    {
        bool isPreviousFloorUnlocked = floorsManager.floors[index - 1].GetComponent<FloorManager>().isUnlocked;
        if (isPreviousFloorUnlocked)
        {
            if (coins.TrySpendCoins(floorPrice))
            {
                isUnlocked = true;
                locked.SetActive(false);
            }
        }
    }
    public void SetUpFloor(int pIndex, int pLevel, int pBasisIncome, int pFloorPrice, int pBasisUpgradePrice, float pBasisDuration, bool pIsUnlocked, Coins pCoins)
    {

        formatter = new NumberFormatter();
        timer = GetComponent<Timer>();
        floorsManager = FindFirstObjectByType<FloorsManager>();
        upgrader = GetComponent<FloorUpgrade>();
        coins = pCoins;
        timer.OnTimerComplete += AddToCurrentResources;

        index = pIndex;

        ChangeCurrentResources(0);

        isUnlocked = pIsUnlocked;
        floorPrice = pFloorPrice;

        if (isUnlocked)
        {
            locked.SetActive(false);
        }
        else
        {
            priceText.text = formatter.FormatNumber(floorPrice).ToString();
        }

        currentResources = 0;

        upgrader.UpdateStats(pLevel, pBasisIncome, pBasisUpgradePrice, pBasisDuration);
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    public float income;
    public float maxResources;
    public float duration;

    public float currentResources;
    bool currentResourcesChanged;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    [SerializeField] int floorIndex;
    public List<bool> buildingFloor;

    int floorPrice;
    bool isUnlocked;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;

    Timer timer;
    FloorUpgrade upgrader;
    NumberFormatter formatter;
    public Coins coins;
    [SerializeField] Image imageStatus;

    private void Update()
    {
        if (timer.isRunning)
        {
            UpdateProgressBar();
        }
        else if (imageStatus.fillAmount > 0.995f)
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
        imageStatus.fillAmount = timer.progresPercentage / 100f;
    }
    void AddToCurrentResources()
    {
        ChangeCurrentResources(income);
    }
    public void BuyFloor()
    {
        if (coins.TrySpendCoins(floorPrice))
        {
            switch (FindFirstObjectByType<SceneChecker>().buildingNumber)
            {
                case 0:
                    buildingFloor = PlayerDataManager.Instance.playerData.building0Dealers;
                    break;
                case 1:
                    buildingFloor = PlayerDataManager.Instance.playerData.building1Dealers;
                    break;
                case 2:
                    buildingFloor = PlayerDataManager.Instance.playerData.building2Dealers;
                    break;
                case 3:
                    buildingFloor = PlayerDataManager.Instance.playerData.building3Dealers;
                    break;
            }
            buildingFloor[floorIndex] = true;
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
            priceText.text = formatter.FormatNumber(floorPrice).ToString();
        }

        currentResources = 0;

        upgrader.UpdateStats(pLevel, pBasisIncome, pBasisUpgradePrice, pBasisDuration);
    }
}

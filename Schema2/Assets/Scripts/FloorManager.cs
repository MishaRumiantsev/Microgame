using TMPro;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    int basisIncome;
    int basisMaxIncome;
    float maxIncome;
    float income;
    public float currentIncome;

    int level;
    int basisPrice;
    float price;

    float priceIncreaseFactor;
    float incomeIncreaseFactor;
    float durationIncreaseFactor;
    float maxIncomeIncreaseFactor;

    float basisDuration;
    float duration;
    Timer timer;

    bool currentIncomeChanged;

    [SerializeField] Coins coins;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] TextMeshProUGUI status;
    [SerializeField] TextMeshProUGUI currentIncomeText;


    private void Start()
    {
        incomeIncreaseFactor = 1.2f;
        durationIncreaseFactor = 0.95f;
        maxIncomeIncreaseFactor = 1.5f;
        priceIncreaseFactor = 1.5f;

        timer = GetComponent<Timer>();
        timer.OnTimerComplete += AddToCurrentIncome;

        ChangeCurrentIncome(0);
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
        if (currentIncomeChanged)
        {
            currentIncomeText.text = currentIncome.ToString();
            currentIncomeChanged = false;
        }
    }
    public void OnClick()
    {
        if (!timer.isRunning)
        {
            timer.StartTimer(duration);
        }
    }
    public void Upgrade()
    {
        if (coins.TrySpendCoins(price))
        {
            level++;
            levelText.text = level.ToString();
            CalculateDuration();
            CalculateIncome();
            CalculateMaxIncome();
            CalculatePrice();
        }
    }

    public void ChangeCurrentIncome(float pAmount)
    {
        currentIncome += pAmount;
        if (currentIncome > maxIncome)
        {
            currentIncome = maxIncome;
        }
        currentIncomeChanged = true;
    }
    void UpdateProgressBar()
    {
        status.text = $"Working {timer.timeRemainingPercentage}%";
    }
    void AddToCurrentIncome()
    {
        ChangeCurrentIncome(income);
    }
    public void SetUpFloor(int pLevel, int pBasisIncome, int pBasisPrice, float pBasisDuration)
    {
        level = pLevel;
        levelText.text = level.ToString();

        basisPrice = pBasisPrice;
        basisIncome = pBasisIncome;
        basisDuration = pBasisDuration;

        basisMaxIncome = pBasisIncome * 5;

        currentIncome = 0;

        CalculateIncome();
        CalculateDuration();
        CalculateMaxIncome();
        CalculatePrice();
    }
    void CalculateIncome()
    {
        income = basisIncome * Mathf.Pow(incomeIncreaseFactor, level);
    }
    void CalculateDuration()
    {
        duration = basisDuration * Mathf.Pow(durationIncreaseFactor, level);
    }
    void CalculateMaxIncome()
    {
        maxIncome = basisMaxIncome * Mathf.Pow(maxIncomeIncreaseFactor,level);
    }
    void CalculatePrice()
    {
        price = basisPrice * Mathf.Pow(priceIncreaseFactor, level);
        priceText.text = price.ToString();
    }
}

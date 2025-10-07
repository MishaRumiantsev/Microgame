using TMPro;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    long income;
    long maxIncome;
    public long currentIncome;
    int level;
    float duration;
    Timer timer;

    [SerializeField] TextMeshProUGUI status;
    [SerializeField] TextMeshProUGUI currentIncomeText;


    private void Start()
    {
        timer = GetComponent<Timer>();
        timer.OnTimerComplete += AddToCurrentIncome;
        currentIncome = 0;
    }
    private void Update()
    {
        if (timer.isRunning)
        {
            UpdateProgressBar();
        }
    }
    public void OnClick()
    {
        if (!timer.isRunning)
        {
            timer.StartTimer(duration);
        }
    }

    void UpdateProgressBar()
    {
        status.text = $"Working {timer.timeRemainingPercentage}%";
    }
    void AddToCurrentIncome()
    {
        status.text = $"Inactive";
        currentIncome += income;
        if (currentIncome > maxIncome)
        {
            currentIncome = maxIncome;
        }
        UpdateIncome();
    }
    public void SetUpFloor(int pLevel, long pIncome, float pDuration)
    {
        level = pLevel;
        income = pIncome;
        maxIncome = pIncome * 5;
        currentIncome = 0;
        duration = pDuration;
    }
    public void UpdateIncome()
    {
        currentIncomeText.text = currentIncome.ToString();
    }
}

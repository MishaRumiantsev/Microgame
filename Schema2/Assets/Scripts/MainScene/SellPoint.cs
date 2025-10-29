using System;
using TMPro;
using UnityEngine;

public class SellPoint : MonoBehaviour
{
    float sellSpeed;
    Timer timer;
    NumberFormatter formatter;

    [SerializeField] Coins coins;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    private void Start()
    {
        formatter = new NumberFormatter();
        timer = GetComponent<Timer>();
        sellSpeed = 5f;
        currentResourcesText.text = PlayerDataManager.storedSellPointCoins.ToString();
    }
    public void AddResources(float pResources)
    {
        PlayerDataManager.storedSellPointCoins += Convert.ToInt32(pResources);
        currentResourcesText.text = formatter.FormatNumber(PlayerDataManager.storedSellPointCoins);
    }
    public void OnClick()
    {
        if (PlayerDataManager.storedSellPointCoins > 0 && !timer.isRunning)
        {
            timer.StartTimer(sellSpeed);
            timer.OnTimerComplete += EndSelling;
            statusText.text = "Selling";
        } 
        else if (timer.isRunning)
        {
            float reduction = Mathf.Min(sellSpeed * 0.05f, 5f);
            timer.timeRemaining = Mathf.Max(timer.timeRemaining - reduction, 0);
        }
    }
    void EndSelling()
    {
        timer.OnTimerComplete -= EndSelling;
        statusText.text = "Inactive";
        coins.ChangeCoins(PlayerDataManager.storedSellPointCoins);
        PlayerDataManager.storedSellPointCoins = 0;
        currentResourcesText.text = formatter.FormatNumber(PlayerDataManager.storedSellPointCoins);
    }
}

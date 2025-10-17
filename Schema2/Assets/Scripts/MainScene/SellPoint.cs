using System;
using TMPro;
using UnityEngine;

public class SellPoint : MonoBehaviour
{
    bool active;
    float sellSpeed;
    Timer timer;

    [SerializeField] Coins coins;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] TextMeshProUGUI currentResourcesText;

    private void Start()
    {
        timer = GetComponent<Timer>();
        sellSpeed = 5f;
        active = false;
        currentResourcesText.text = PlayerDataManager.storedSellPointCoins.ToString();
    }
    public void AddResources(float pResources)
    {
        PlayerDataManager.storedSellPointCoins += Convert.ToInt32(pResources);
        currentResourcesText.text = PlayerDataManager.storedSellPointCoins.ToString();
    }
    public void OnClick()
    {
        if (PlayerDataManager.storedSellPointCoins > 0 && !active)
        {
            active = true;
            timer.StartTimer(sellSpeed);
            timer.OnTimerComplete += EndSelling;
            statusText.text = "Selling";
        }
    }
    void EndSelling()
    {
        timer.OnTimerComplete -= EndSelling;
        active = false;
        statusText.text = "Inactive";
        coins.ChangeCoins(PlayerDataManager.storedSellPointCoins);
        PlayerDataManager.storedSellPointCoins = 0;
        currentResourcesText.text = PlayerDataManager.storedSellPointCoins.ToString();
    }
}

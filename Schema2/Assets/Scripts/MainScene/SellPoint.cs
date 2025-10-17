using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class SellPoint : MonoBehaviour
{
    float currentResources;
    bool active;
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
        active = false;
        currentResourcesText.text = currentResources.ToString();
    }
    public void AddResources(float pResources)
    {
        currentResources += pResources;
        currentResourcesText.text = formatter.FormatNumber(currentResources);
    }
    public void OnClick()
    {
        if (currentResources > 0 && !active)
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
        coins.ChangeCoins(currentResources);
        currentResources = 0;
        currentResourcesText.text = formatter.FormatNumber(currentResources);
    }
}

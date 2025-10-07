using TMPro;
using UnityEngine;

public class SellPoint : MonoBehaviour
{
    long currentResources;
    long coins;
    bool active;
    float sellSpeed;
    Timer timer;

    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] TextMeshProUGUI currentResourcesText;
    [SerializeField] TextMeshProUGUI coinsText;

    private void Start()
    {
        timer = GetComponent<Timer>();
        coins = 0;
        sellSpeed = 5f;
        active = false;
    }
    public void AddResources(long pResoursec)
    {
        currentResources += pResoursec;
        currentResourcesText.text = currentResources.ToString();
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
        coins += currentResources;
        coinsText.text = $"Coins: {coins}";
        currentResources = 0;
        currentResourcesText.text = currentResources.ToString();
    }
}

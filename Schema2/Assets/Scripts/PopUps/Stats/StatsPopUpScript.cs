using System;
using TMPro;
using UnityEngine;

public class StatsPopUpScript : MonoBehaviour
{
    public static StatsPopUpScript Instance { get; private set; }

    [SerializeField] TextMeshProUGUI totalCoinsText;
    [SerializeField] TextMeshProUGUI totalSpentText;
    [SerializeField] TextMeshProUGUI gainedOfflineText;
    [SerializeField] TextMeshProUGUI totalUpgradesText;
    [SerializeField] TextMeshProUGUI playTimeText;

    NumberFormatter formatter;

    private void Awake()
    {
        formatter = new NumberFormatter();
        // Ensures only one StatsPopUpScript exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        totalCoinsText.text = $"Total Coins: {formatter.FormatNumber(PlayerDataManager.totalCoins)}";
        totalSpentText.text = $"Total Spent: {formatter.FormatNumber(PlayerDataManager.totalSpent)}";
        gainedOfflineText.text = $"Gained Offline: {formatter.FormatNumber(PlayerDataManager.gainedOffline)}";
        totalUpgradesText.text = $"Total upgrades: {formatter.FormatNumber(PlayerDataManager.totalUpgrades)}";
        playTimeText.text = $"Play time: {TimeSpan.FromSeconds(PlayerDataManager.playTime).TotalHours:F2}h";
    }


}

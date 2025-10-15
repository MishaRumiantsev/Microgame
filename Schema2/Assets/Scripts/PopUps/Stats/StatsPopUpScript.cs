using TMPro;
using UnityEngine;

public class StatsPopUpScript : MonoBehaviour
{
    public static StatsPopUpScript Instance { get; private set; }

    [SerializeField] TextMeshProUGUI totalCoinsText;
    [SerializeField] TextMeshProUGUI totalSpentText;
    [SerializeField] TextMeshProUGUI gainedOfflineText;


    private void Awake()
    {
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
        totalCoinsText.text = $"Total Coins: {PlayerDataManager.totalCoins}";
        totalSpentText.text = $"Total Spent: {PlayerDataManager.totalSpent}";
        gainedOfflineText.text = $"Gained Offline: {PlayerDataManager.gainedOffline}";
    }


}

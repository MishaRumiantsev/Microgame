using UnityEngine;

public class PlayerDataPrefs : MonoBehaviour
{
    public int money;
    public int liftMoney;
    public int prestigeCoins;

    private void Start()
    {
        LoadData();

        // Example: modify data
        money += 100;
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("LiftMoney", liftMoney);
        PlayerPrefs.SetInt("PrestigeCoins", prestigeCoins);
        PlayerPrefs.Save();

        Debug.Log("? Data saved using PlayerPrefs");
    }

    public void LoadData()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        liftMoney = PlayerPrefs.GetInt("LiftMoney", 0);
        prestigeCoins = PlayerPrefs.GetInt("PrestigeCoins", 0);

        Debug.Log($"?? Loaded: money={money}, liftMoney={liftMoney}, prestigeCoins={prestigeCoins}");
    }
}

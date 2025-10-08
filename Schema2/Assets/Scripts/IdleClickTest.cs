using UnityEngine;
using TMPro;
using System;

public class IdleClickTest : MonoBehaviour
{
    public int money;
    public int pasiveMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI pasiveMoneyText;
    int pUpgrade;

    void Start()
    {
        LoadPlayerData();
        LoadIdleTime();
        if (pUpgrade > 0)
            for (int i = 0; i < pUpgrade; i++) PasiveMoneyUpgrade(); 
    }

    void Update()
    {
        moneyText.text = $"Money: {money}";
        pasiveMoneyText.text = $"pMoney: {pasiveMoney}";
    }

    public void OnClick()
    {
        money++;
        SavePlayerData();
    }

    public void OnClickPasive()
    {
        InvokeRepeating(nameof(PasiveMoney), 0f, 0.5f);
        pUpgrade++;
    }

    void PasiveMoneyUpgrade()
    {
        InvokeRepeating(nameof(PasiveMoney), 0f, 0.5f);
    }

    public void OnClickDelete()
    {
        DeletePLayerData();
    }

    private void PasiveMoney()
    {
        pasiveMoney++;
        SavePlayerData();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            SaveQuitTime();
            SavePlayerData();
        }
        else
        {
            LoadPlayerData();
            LoadIdleTime();
        }
    }

    void OnApplicationQuit()
    {
        SaveQuitTime();
        SavePlayerData();
    }

    // ------------------------------
    // SAVE / LOAD
    // ------------------------------

    private void SavePlayerData()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("PasiveMoney", pasiveMoney);
        PlayerPrefs.SetInt("Upgrades", pUpgrade);
        PlayerPrefs.Save();
        Debug.Log($"💾 Saved: money={money}, pMoney={pasiveMoney}");
    }

    private void LoadPlayerData()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        pasiveMoney = PlayerPrefs.GetInt("PasiveMoney", 0);
        pUpgrade = PlayerPrefs.GetInt("Upgrades", 0);
        Debug.Log($"📦 Loaded: money={money}, pMoney={pasiveMoney}");
    }

    private void DeletePLayerData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        money = 0;
        pasiveMoney = 0;
        pUpgrade = 0;
        CancelInvoke();

        Debug.Log("All progress reset!");
    }

    private void SaveQuitTime()
    {
        string now = DateTime.UtcNow.ToString();
        PlayerPrefs.SetString("LastQuitTime", now);
        PlayerPrefs.Save();
    }

    private void LoadIdleTime()
    {
        if (PlayerPrefs.HasKey("LastQuitTime"))
        {
            string saved = PlayerPrefs.GetString("LastQuitTime");
            DateTime lastQuitTime = DateTime.Parse(saved);
            TimeSpan timeAway = DateTime.UtcNow - lastQuitTime;

            Debug.Log($"⏳ Away for {timeAway.TotalSeconds:F0} seconds");
            GiveIdleRewards(timeAway);
        }
    }

    private void GiveIdleRewards(TimeSpan timeAway)
    {
        int earned = Mathf.FloorToInt((float)timeAway.TotalSeconds * 2f);
        money += earned;
        SavePlayerData();
        Debug.Log($"💰 Earned {earned} while away!");
    }
}

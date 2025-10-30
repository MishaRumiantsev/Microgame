using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;
    public PlayerData playerData = new PlayerData();

    FloorsManager floorsManager;

    private string savePath;
    private DateTime lastOnlineTime;
    float sessionStartTime;

    //how to call the coins
    //PlayerDataManager.Coins
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/playerdata.json";
            print(savePath);
            LoadPlayerData();
            CalculateOfflineEarnings();
            sessionStartTime = Time.time;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SavePlayerData()
    {
        // Save last online time too
        playerDataJsonWrapper wrapper = new playerDataJsonWrapper
        {
            data = playerData,
            lastOnlineTime = DateTime.Now.ToString()
        };
        floorsManager = FindFirstObjectByType<FloorsManager>();
        floorsManager.SavePassiveIncomeOfBuilding();

        playTime += Time.time - sessionStartTime;
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Player data saved!");
    }
    public void LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            playerDataJsonWrapper wrapper = JsonUtility.FromJson<playerDataJsonWrapper>(json);
            playerData = wrapper.data;
            if (!string.IsNullOrEmpty(wrapper.lastOnlineTime))
                lastOnlineTime = DateTime.Parse(wrapper.lastOnlineTime);
            Debug.Log("Player data loaded!");
        }
        else
        {
            playerData = new PlayerData();
            lastOnlineTime = DateTime.Now;
            Debug.Log("No save file found, creating new data.");
        }
    }
    public void DeleteAllPlayerData()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("All player data deleted from disk.");
        }

        // Reset in-memory data too
        playerData = new PlayerData();
        lastOnlineTime = DateTime.Now;

        Debug.Log("Player data reset in memory.");
    }
    private void CalculateOfflineEarnings()
    {
        if (lastOnlineTime == DateTime.MinValue)
            return;

        TimeSpan offlineTime = DateTime.Now - lastOnlineTime;
        double secondsAway = offlineTime.TotalSeconds;

        double passiveIncome = 0;
        passiveIncome += CalculatePassiveIncomeOfBuilding(Instance.playerData.building0PassiveIncome);
        passiveIncome += CalculatePassiveIncomeOfBuilding(Instance.playerData.building1PassiveIncome);
        passiveIncome += CalculatePassiveIncomeOfBuilding(Instance.playerData.building2PassiveIncome);
        passiveIncome += CalculatePassiveIncomeOfBuilding(Instance.playerData.building3PassiveIncome);

        long coinsEarned = (long)(passiveIncome * secondsAway);

        if (coinsEarned > 0)
        {
            playerData.coins += coinsEarned;
            gainedOffline += coinsEarned;
        }
    }
    double CalculatePassiveIncomeOfBuilding(List<double> pBuildingPassiveIncome)
    {
        double passiveIncome = 0;
        for (int i = 0; i < pBuildingPassiveIncome.Count; i++)
        {
            passiveIncome += pBuildingPassiveIncome[i];
        }
        return passiveIncome;
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SavePlayerData();
        }
        else
        {
            sessionStartTime = Time.time;
        }
    }
    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
    [Serializable]
    private class playerDataJsonWrapper
    {
        public PlayerData data;
        public string lastOnlineTime;
    }

    public static long Coins
    {
        get => Instance.playerData.coins;
        set => Instance.playerData.coins = value;
    }

    public static long storedSellPointCoins
    {
        get => Instance.playerData.storedSellPointCoins;
        set => Instance.playerData.storedSellPointCoins = value;
    }

    public static long totalCoins
    {
        get => Instance.playerData.totalCoins;
        set => Instance.playerData.totalCoins = value;
    }

    public static long totalSpent
    {
        get => Instance.playerData.totalCoins - Instance.playerData.coins;
    }

    public static long gainedOffline
    {
        get => Instance.playerData.gainedOffline;
        set => Instance.playerData.gainedOffline = value;
    }
    public static double playTime
    {
        get => Instance.playerData.playTime;
        set => Instance.playerData.playTime = value;
    }
    public static long totalUpgrades
    {
        get => Instance.playerData.totalUpgrades;
        set => Instance.playerData.totalUpgrades = value;
    }
}

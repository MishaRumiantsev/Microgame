using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;
using NUnit.Framework;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;
    public PlayerData playerData = new PlayerData();

    private string savePath;
    private DateTime lastOnlineTime;

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
        double hoursAway = offlineTime.TotalHours;

        // Example: 100 coins per hour offline
        int coinsEarned = Mathf.FloorToInt((float)(hoursAway * 100));

        if (coinsEarned > 0)
        {
            playerData.coins += coinsEarned;
            Debug.Log($"You were away for {hoursAway:F2} hours and earned {coinsEarned} coins!");
        }

        gainedOffline = coinsEarned;
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause) SavePlayerData();
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
    public static int Coins
    {
        get => Instance.playerData.coins;
        set => Instance.playerData.coins = value;
    }
    public static int storedSellPointCoins
    {
        get => Instance.playerData.storedSellPointCoins;
        set => Instance.playerData.storedSellPointCoins = value;
    }
    public static int totalCoins
    {
        get => Instance.playerData.totalCoins;
        set => Instance.playerData.totalCoins = value;
    }
    public static int totalSpent
    {
        get => Instance.playerData.totalCoins - Instance.playerData.coins;
    }
    public static int gainedOffline
    {
        get => Instance.playerData.gainedOffline;
        set => Instance.playerData.gainedOffline = value;
    }
}

using System.Collections.Generic;

[System.Serializable]

//how to call the stats
//PlayerDataManager.Coins

public class PlayerData
{
    public long coins;
    public long storedSellPointCoins;

    //stats
    public long totalCoins;
    public long gainedOffline;
    public double playTime;
    public long totalUpgrades;

    public float sfxVolume;
    public float musicVolume;

    public List<bool> building0Floors = new List<bool>() { true, false, false };
    public List<int> building0Upgrades = new List<int>() { 0, 0, 0 };
    public List<int> building0Resources = new List<int>() { 0, 0, 0 };
    public List<double> building0PassiveIncome = new List<double> { 0, 0, 0 };
    public List<bool> building0Dealers = new List<bool>() { false, false, false };

    public List<bool> building1Floors = new List<bool>() { true, false, false, false, false };
    public List<int> building1Upgrades = new List<int>() { 0, 0, 0, 0, 0 };
    public List<int> building1Resources = new List<int>() { 0, 0, 0, 0, 0 };
    public List<double> building1PassiveIncome = new List<double> { 0, 0, 0 , 0, 0};
    public List<bool> building1Dealers = new List<bool>() { false, false, false, false, false };

    public List<bool> building2Floors = new List<bool>() { true, false, false, false, false, false, false };
    public List<int> building2Upgrades = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
    public List<int> building2Resources = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
    public List<double> building2PassiveIncome = new List<double> { 0, 0, 0, 0, 0, 0, 0 };
    public List<bool> building2Dealers = new List<bool>() { false, false, false, false, false, false, false };

    public List<bool> building3Floors = new List<bool>() { true, false, false, false, false, false, false, false, false, false };
    public List<int> building3Upgrades = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<int> building3Resources = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<double> building3PassiveIncome = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<bool> building3Dealers = new List<bool>() { false, false, false, false, false, false, false, false, false, false };


    public List<int> elevatorUpgrades = new List<int>() { 0, 0, 0, 0 };
}
using System.Xml.Schema;

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

}

using UnityEngine;
using TMPro;
using System;

public class IdleClickTest : MonoBehaviour
{
    public int money;
    public int pasiveMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI pasiveMoneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"Money: {money.ToString()}";
        pasiveMoneyText.text = $"pMoney: {pasiveMoney.ToString()}";
    }

    public void OnClick() 
    {
        money++;
    }

    //invoke cancelen, tijd verlagen en dan weer aanzetten
    public void OnClickPasive()
    {
        InvokeRepeating("PasiveMoney", 1f, 3f);
    }


    public void PasiveMoney()
    {
        pasiveMoney++;
    }

    private const string LastQuitTimeKey = "LastQuitTime";

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // Game gained focus → player returned
            if (PlayerPrefs.HasKey(LastQuitTimeKey))
            {
                string lastQuitTimeString = PlayerPrefs.GetString(LastQuitTimeKey);
                DateTime lastQuitTime = DateTime.Parse(lastQuitTimeString);

                TimeSpan timeAway = DateTime.Now - lastQuitTime;

                Debug.Log($"Player was away for {timeAway.TotalSeconds:F0} seconds");

                // Example: give idle rewards
                //GiveIdleRewards(timeAway);
            }
        }
        else
        {
            // Game lost focus → player leaving
            PlayerPrefs.SetString(LastQuitTimeKey, DateTime.Now.ToString());
            PlayerPrefs.Save();
        }
    }
}

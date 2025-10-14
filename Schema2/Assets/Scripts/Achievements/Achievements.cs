using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class AchievementList
{
    public string achievementName;
    public string achievementDescription;
    public int amountOfCoinsNeeded;
    public bool isAchievementActive;
}
public class Achievements : MonoBehaviour
{
    //Alle achievements in de game
    /*public bool IkClicks = false;
    public bool IOkClicks = false;
    public bool IkMoney = false;
    public bool IOkMoney = false;
    public bool IOOkMoney = false;
    public bool ImMoney = false;
    public bool tweedeVerdieping = false;
    public bool derdeVerieping = false;
    public bool vierdeVerdieping = false;
    public bool vijfdeVerdieping = false;
    public bool bladSchaapSlak = false;*/
    public GetCoinsFromButton GetCoins;
    public List<AchievementList> achievements = new List<AchievementList>();
    [SerializeField] private PopUpManagerAchievements popUpManagerAchievements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        achievements.Add(new AchievementList { achievementName = "Rich", achievementDescription = "Get 10 coins", amountOfCoinsNeeded = 10, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "Richer", achievementDescription = "Get 20 coins", amountOfCoinsNeeded = 20, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "Richest", achievementDescription = "Get 10.000 coins",amountOfCoinsNeeded = 10000, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "SO RICH", achievementDescription = "Get 100.000 coins", amountOfCoinsNeeded = 100000, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "MILLIONAIRE", achievementDescription = "Get 1.000.000 coins", amountOfCoinsNeeded = 1000000, isAchievementActive = false });
        //achievements.Add(new AchievementList { achievementName = "Extra space", amountOfCoinsNeeded = 2000, isAchievementActive = false });
        //achievements.Add(new AchievementList { achievementName = "Third flood", amountOfCoinsNeeded = 3000, isAchievementActive = false });
        //achievements.Add(new AchievementList { achievementName = "So much space...", amountOfCoinsNeeded = 4000, isAchievementActive = false });
        //achievements.Add(new AchievementList { achievementName = "Skyscraper", amountOfCoinsNeeded = 5000, isAchievementActive = false });
        //achievements.Add(new AchievementList { achievementName = "bladSchaapSlak", amountOfCoinsNeeded = 50, isAchievementActive = false });
    }

    // Update is called once per frame
    void Update()
    {
        if (GetCoins.testCoin == 5)
        {
            //Debug.Log("testing 5");
        }
        foreach (var achievement in achievements)
        {
            if (achievement.isAchievementActive == false && GetCoins.testCoin >= achievement.amountOfCoinsNeeded)
            {
                achievement.isAchievementActive = true;
                Debug.Log($"Achievement unlocked: {achievement.achievementName} ({achievement.amountOfCoinsNeeded} coins)");
                popUpManagerAchievements.ShowPopup(achievement.achievementName, achievement.achievementDescription);
                //string title = achievement.achievementName;
                //string description = $"Je hebt {achievement.amountOfCoinsNeeded} coins verzameld!";

                //popUpManagerAchievements.ShowPopup(title, destripion);

            }
        }





        /*
        switch (GetCoins.testCoin) {
            case 1000:
                IkClicks = true;
                break;
            case 10000:
                IOkClicks = true;
                break;
        }
        switch (GetCoins.testCoin) {
            case 10:
                IkMoney = true;
                Debug.Log("test");
                break;
            case 10000:
                IOkMoney = true;
                break;
            case 100000:
                IOOkMoney = true;
                break;
            case 1000000:
                ImMoney = true;
                break;
            default:
                break;
        }*/
    }
}

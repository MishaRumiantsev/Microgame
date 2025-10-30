using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class AchievementList
{
    //Hier de variabelen die ik in de achievements nodig heb.
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
    //Een list waar ik alle achievements in heb gezet.
    [SerializeField] private PopUpManagerAchievements popUpManagerAchievements;
    void Start()
    {
        achievements.Add(new AchievementList { achievementName = "Rich", achievementDescription = "Get 10 coins", amountOfCoinsNeeded = 10, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "Richer", achievementDescription = "Get 1000 coins", amountOfCoinsNeeded = 1000, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "Richest", achievementDescription = "Get 10.000 coins", amountOfCoinsNeeded = 10000, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "SO RICH", achievementDescription = "Get 100.000 coins", amountOfCoinsNeeded = 100000, isAchievementActive = false });
        achievements.Add(new AchievementList { achievementName = "MILLIONAIRE", achievementDescription = "Get 1.000.000 coins", amountOfCoinsNeeded = 1000000, isAchievementActive = false });
        //Hierboven alle achievements die ik gemaakt heb
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
                popUpManagerAchievements.ShowPopup(achievement.achievementName, achievement.achievementDescription);
                //Zo laat ik de popup zien, met de naam en describtion
            }
        }
    }
}
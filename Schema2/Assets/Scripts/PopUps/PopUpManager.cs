using UnityEngine;

/// <summary>
/// This script manages the display and closure of different pop-up windows in the game.
/// </summary>

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance { get; private set; }

    private GameObject currentPopUp;

    // Assign the pop up prefabs in the inspector
    public GameObject BattlePass_PopUp;
    public GameObject Achievements_PopUp;
    public GameObject Stats_PopUp;
    public GameObject Dealers_PopUp;
    public GameObject Prestige_PopUp;

    private void Awake()
    {
        // Ensures only one PopUpManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void ShowPopUp(GameObject popUpPrefab)
    {
        // Close existing pop up
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
        }

        // Spawn new one
        currentPopUp = Instantiate(popUpPrefab, Vector3.zero, Quaternion.identity);
    }

    public void CloseCurrentPopUp()
    {
        // Destroy the current pop up if it exists
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
            currentPopUp = null;
        }
    }

    public void BattlePassButton()
    {
        // Spawn the Battle Pass pop up prefab
        Debug.Log("Battle Pass Button Clicked");
        ShowPopUp(BattlePass_PopUp);
    }

    public void AchievementsButton()
    {
        // Spawn the Achievements pop up prefab
        Debug.Log("Achievements Button Clicked");
        ShowPopUp(Achievements_PopUp);
    }

    public void StatsButton()
    {
        // Spawn the Stats pop up prefab
        Debug.Log("Stats Button Clicked");
        ShowPopUp(Stats_PopUp);
    }

    public void DealersButton()
    {
        // Spawn the Dealers pop up prefab
        Debug.Log("Dealers Button Clicked");
        ShowPopUp(Dealers_PopUp);
    }

    public void PrestigeButton()
    {
        // Spawn the Prestige pop up prefab
        Debug.Log("Prestige Button Clicked");
        ShowPopUp(Prestige_PopUp);
    }
}

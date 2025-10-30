using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script manages the display and closure of different pop-up windows in the game.
/// </summary>

public class PopUpManagerUI : MonoBehaviour
{
    public static PopUpManagerUI Instance { get; private set; }

    private GameObject currentPopUp;

    // Assign the pop up prefabs in the inspector
    [SerializeField] GameObject BattlePass_PopUp;
    [SerializeField] GameObject Achievements_PopUp;
    [SerializeField] GameObject Stats_PopUp;
    [SerializeField] GameObject Dealers_PopUp;
    [SerializeField] GameObject Dealers_PopUp_1;
    [SerializeField] GameObject Dealers_PopUp_2;
    [SerializeField] GameObject Dealers_PopUp_3;
    [SerializeField] GameObject Dealers_PopUp_4;

    [SerializeField] GameObject Prestige_PopUp;
    [SerializeField] GameObject FloorUpgrade_PopUp;
    [SerializeField] GameObject ElevatorUpgrade_PopUp;

    private AudioSource audioSource;

    [SerializeField] private AudioClip buttonSoundUI;

    string sceneName;

    private void Awake()
    {
        // Ensures only one PopUpManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        Debug.Log($"Attempting to close popup. currentPopUp is {(currentPopUp == null ? "null" : "not null")}");
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
            currentPopUp = null;
            Debug.Log("Popup destroyed.");
        }
        else
        {
            Debug.LogWarning("No popup to close.");
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
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Prestige_0": 
                ShowPopUp(Dealers_PopUp_1);
                break;
            case "Prestige_1": 
                ShowPopUp(Dealers_PopUp_2);
                break;
            case "Prestige_2":
                ShowPopUp(Dealers_PopUp_3);
                break;
            case "Prestige_3": 
                ShowPopUp(Dealers_PopUp_4);
                break;
            default:
                ShowPopUp(Dealers_PopUp);
                break;
        }
    }

    public void PrestigeButton()
    {
        // Spawn the Prestige pop up prefab
        Debug.Log("Prestige Button Clicked");
        ShowPopUp(Prestige_PopUp);
    }
    public void FloorLevelButton(int floorIndex)
    {
        ShowPopUp(FloorUpgrade_PopUp);
        FloorUpgradePopUp popUpScript = currentPopUp.GetComponent<FloorUpgradePopUp>();
        popUpScript.index = floorIndex;
    }
    public void ElevatorLevelButton()
    {
        ShowPopUp(ElevatorUpgrade_PopUp);
    }
}

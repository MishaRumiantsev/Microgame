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

    [SerializeField] GameObject Settings_PopUp;

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

    public void ShowPopUp(GameObject popUpPrefab)
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.popUpOpen, transform, 1f);
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
        SfxManager.instance.PlaySfxClip(SfxManager.instance.popUpClose, transform, 1f);
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
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        // Spawn the Battle Pass pop up prefab
        Debug.Log("Battle Pass Button Clicked");
        ShowPopUp(BattlePass_PopUp);
    }

    public void AchievementsButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        // Spawn the Achievements pop up prefab
        Debug.Log("Achievements Button Clicked");
        ShowPopUp(Achievements_PopUp);
    }

    public void StatsButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        // Spawn the Stats pop up prefab
        Debug.Log("Stats Button Clicked");
        ShowPopUp(Stats_PopUp);
    }

    public void DealersButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
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
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        // Spawn the Prestige pop up prefab
        Debug.Log("Prestige Button Clicked");
        ShowPopUp(Prestige_PopUp);
    }
    public void FloorLevelButton(int floorIndex)
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        ShowPopUp(FloorUpgrade_PopUp);
        FloorUpgradePopUp popUpScript = currentPopUp.GetComponent<FloorUpgradePopUp>();
        popUpScript.index = floorIndex;
    }
    public void ElevatorLevelButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        ShowPopUp(ElevatorUpgrade_PopUp);
    }

    public void SettingsButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        Debug.Log("Settings Button Clicked");
        ShowPopUp(Settings_PopUp);
    }

    public void FlapButton()
    {
        SfxManager.instance.PlaySfxClip(SfxManager.instance.buttonSfx, transform, 1f);
        Debug.Log("Flappy Button Clicked");
        SceneManager.LoadScene("FlappyBird2");
    }
}

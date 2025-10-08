using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance { get; private set; }

    private GameObject currentPopUp;

    public GameObject BattlePass_PopUp;
    public GameObject Achievements_PopUp;
    public GameObject Stats_PopUp;
    public GameObject Dealers_PopUp;
    public GameObject Prestige_PopUp;

    private void Awake()
    {
        // Singleton pattern — ensures only one PopUpManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // optional if you want persistence between scenes
    }

    public void ShowPopUp(GameObject popUpPrefab)
    {
        // Close existing one
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
        }

        // Spawn new one (you can also make it a child of the canvas if you like)
        currentPopUp = Instantiate(popUpPrefab, Vector3.zero, Quaternion.identity);
    }

    public void CloseCurrentPopUp()
    {
        if (currentPopUp != null)
        {
            Destroy(currentPopUp);
            currentPopUp = null;
        }
    }

    public void BattlePassButton()
    {
        Debug.Log("Battle Pass Button Clicked");
        ShowPopUp(BattlePass_PopUp);
    }

    public void AchievementsButton()
    {
        Debug.Log("Achievements Button Clicked");
        ShowPopUp(Achievements_PopUp);
    }

    public void StatsButton()
    {
        Debug.Log("Stats Button Clicked");
        ShowPopUp(Stats_PopUp);
    }

    public void DealersButton()
    {
        Debug.Log("Dealers Button Clicked");
        ShowPopUp(Dealers_PopUp);
    }

    public void PrestigeButton()
    {
        Debug.Log("Prestige Button Clicked");
        ShowPopUp(Prestige_PopUp);
    }
}

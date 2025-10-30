using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    FloorsManager floorsManager;
    private void Start()
    {
        floorsManager = FindAnyObjectByType<FloorsManager>();
    }
    public void GoToBuildingOne()
    {
        floorsManager.SavePassiveIncomeOfBuilding();
        SceneManager.LoadScene("Prestige_0");
        floorsManager = GetComponent<FloorsManager>();
    }
    public void GoToBuildingTwo()
    {
        floorsManager.SavePassiveIncomeOfBuilding();
        SceneManager.LoadScene("Prestige_1");
        floorsManager = GetComponent<FloorsManager>();
    }
    public void GoToBuildingThree()
    {
        floorsManager.SavePassiveIncomeOfBuilding();
        SceneManager.LoadScene("Prestige_2");
        floorsManager = GetComponent<FloorsManager>();
    }
    public void GoToBuildingFour()
    {
        floorsManager.SavePassiveIncomeOfBuilding();
        SceneManager.LoadScene("Prestige_3");
        floorsManager = GetComponent<FloorsManager>();
    }

}

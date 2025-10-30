using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToBuildingOne()
    {
        SceneManager.LoadScene("Prestige_0");
    }
public void GoToBuildingTwo()
    {
        SceneManager.LoadScene("Prestige_1");
    }
    public void GoToBuildingThree()
    {
        SceneManager.LoadScene("Prestige_2");
    }
    public void GoToBuildingFour()
    {
        SceneManager.LoadScene("Prestige_3");
    }

}

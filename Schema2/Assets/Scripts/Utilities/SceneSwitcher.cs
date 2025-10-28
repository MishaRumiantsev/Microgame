using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToWorldOne()
    {
        SceneManager.LoadScene("Prestige_0");
    }
    public void GoToWorldTwo()
    {
        SceneManager.LoadScene("Prestige_1");

    }
    public void GoToWorldThree()
    {
        SceneManager.LoadScene("Prestige_2");

    }
    public void GoToWorldFour()
    {
        SceneManager.LoadScene("Prestige_3");
    }

}

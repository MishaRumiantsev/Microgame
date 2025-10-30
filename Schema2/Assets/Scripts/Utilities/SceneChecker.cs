using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    public int buildingNumber;
    string sceneName;

    //how to call this
    //FindFirstObjectByType<SceneChecker>().buildingNumber

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Prestige_0":
                buildingNumber = 0;
                break;
            case "Prestige_1":
                buildingNumber = 1;
                break;
            case "Prestige_2":
                buildingNumber = 2;
                break;
            case "Prestige_3":
                buildingNumber = 3;
                break;
        }

    }
}

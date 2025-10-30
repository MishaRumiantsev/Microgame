using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager2 : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    [SerializeField] public GameObject coinsInDeathScreen;
    public TextMeshProUGUI coinsInDeathScreenText;

    public static FlappyManager2 instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }
    public void DeathScreen()
    {
        canvas.SetActive(true);
    }
    public void restartGame()
    {
        Time.timeScale = 1f;//zo zet ik de time weer op normaal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}

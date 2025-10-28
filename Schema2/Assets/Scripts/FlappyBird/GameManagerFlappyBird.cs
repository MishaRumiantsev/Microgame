using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerFlappyBird : MonoBehaviour
{
    public static GameManagerFlappyBird instance;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject extraCoinsText;
    public bool extraCoins = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        canvas.SetActive(true);
        if (extraCoins == true)
        {
            extraCoinsText.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        extraCoins = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

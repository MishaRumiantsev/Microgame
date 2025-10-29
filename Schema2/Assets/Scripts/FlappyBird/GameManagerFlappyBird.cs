using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerFlappyBird : MonoBehaviour
{
    public static GameManagerFlappyBird instance;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject extraCoinsText;
    public TextMeshProUGUI tekstFlappyCoins;
    public TextMeshProUGUI tekstFlappyCoinsInGame;
    public bool extraCoins = false;
    public int totalFlappyCoins = 0;

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
            tekstFlappyCoins.text = $"+{totalFlappyCoins} Coins";
            /*if ()
            {
                tekstFlappyCoinsInGame.text = $"Coins: {totalFlappyCoins}";

            }*/
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

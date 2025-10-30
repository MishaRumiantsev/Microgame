using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FlappyBirdMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    private Rigidbody2D Rigidbody;
    [SerializeField] public GameObject canvas;
    [SerializeField] public GameObject coinsInDeathScreen;
    public TextMeshProUGUI coinsInDeathScreenText;
    public int flappyCoins;
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Level"))
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);

            coinsInDeathScreenText.text = "Coins: " + flappyCoins;
            PlayerDataManager.Coins += 2;
            //Zo pas ik de coins van playerDataManager aan en voeg ik 2 toe.
            Rigidbody.linearVelocity = Vector2.zero;
            FlappyManager2.instance.DeathScreen();
            //Zo ga ik naar de flappymanager2 script en call ik de method deathscreen
        }
        else if (collision.CompareTag("Coins"))
        {
            flappyCoins += 2;
        }
    }
    public void jump()
    {
        Rigidbody.linearVelocity = Vector2.up * velocity; //Voor het springen
    }
    /*void DeathScreen()
    {
        canvas.SetActive(true);
        coinsInDeathScreenText.text = "Coins: " + flappyCoins;
    }*/
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Zo laad ik de scene waar hij nu in zit
    }

}

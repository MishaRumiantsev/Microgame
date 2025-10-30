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

    //[SerializeField] public Vector2 spawnPosition = new Vector2(-1f, 0f);
    public int flappyCoins;
    private void Start()
    {

        Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Level"))
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);

            coinsInDeathScreenText.text = "Coins: " + flappyCoins;
            PlayerDataManager.Coins += 2;

            Rigidbody.linearVelocity = Vector2.zero;

            FlappyManager2.instance.DeathScreen();
        }
        else if (collision.CompareTag("Coins"))
        {
            flappyCoins += 2;
            Debug.Log("testing");
        }
    }
    public void jump()
    {
        Rigidbody.linearVelocity = Vector2.up * velocity;
    }
    /*void DeathScreen()
    {
        canvas.SetActive(true);
        coinsInDeathScreenText.text = "Coins: " + flappyCoins;
    }*/
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

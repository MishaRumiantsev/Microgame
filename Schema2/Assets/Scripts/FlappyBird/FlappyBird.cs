using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class FlappyBird : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    GameManagerFlappyBird ExtraCoinsBool;
    private Rigidbody2D rb;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4; 
    public AudioClip sound5;
    public AudioClip sound6;
    private AudioSource audioSource;
     [SerializeField] public Vector2 spawnPosition = new Vector2(-2f, 0f);

    private void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("test);
            rb.linearVelocity = Vector2.up * velocity;
            int rNumber = UnityEngine.Random.Range(1, 6);
            switch (rNumber)
            {
                case 1:
                    audioSource.PlayOneShot(sound1);
                    break;
                case 2:
                    audioSource.PlayOneShot(sound2);
                    break;
                case 3:
                    audioSource.PlayOneShot(sound3);
                    break;
                case 4:
                    audioSource.PlayOneShot(sound4);
                    break;
                case 5:
                    audioSource.PlayOneShot(sound5);
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Level"))
        {
            GameManagerFlappyBird.instance.GameOver();
            transform.position = spawnPosition;
            audioSource.PlayOneShot(sound6);
        }
        if (collision.CompareTag("Finish"))
        {
            GameManagerFlappyBird.instance.GameOver();
            transform.position = spawnPosition;
        }
        if (collision.CompareTag("Coins"))
        {
            PlayerDataManager.Coins += 2;
            GameManagerFlappyBird.instance.totalFlappyCoins += 2;
            GameManagerFlappyBird.instance.extraCoins = true;
        }
    }
}

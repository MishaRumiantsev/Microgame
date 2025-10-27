using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * velocity;
        }
    }
}

using UnityEngine;

public class Fallingobject : MonoBehaviour
{
    public float fallSpeed = 1f;
    public float zigZagSpeed = 2f;
    public float zigZagWidth = 2f;
    private float startX;
    private float rotationSpeed = 10f;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * zigZagSpeed) * zigZagWidth;
        float y = transform.position.y - fallSpeed * Time.deltaTime;
        transform.position = new Vector3(x, y, transform.position.z);
        transform.Rotate(Vector3.forward, - rotationSpeed * Time.deltaTime);
        HandleInput();
        
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                CheckTouch(touch.position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }

    void CheckTouch(Vector2 screenPosition)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Destroy(gameObject);
        }
    }
    void Rotation()
    {
        
    }
}
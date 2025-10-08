using UnityEngine;

public class Fallingobject : MonoBehaviour
{
    public float fallSpeed = 1f;          public float zigZagSpeed = 2f;     
    public float zigZagWidth = 2f;     
    private float startX;

    void Start()
    {
        // Save the starting X position
        startX = transform.position.x;
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * zigZagSpeed) * zigZagWidth;

        
        float y = transform.position.y - fallSpeed * Time.deltaTime;

        
        transform.position = new Vector3(x, y, transform.position.z);

        
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CheckTouch(touch.position);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }

    void CheckTouch(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.gameObject == gameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
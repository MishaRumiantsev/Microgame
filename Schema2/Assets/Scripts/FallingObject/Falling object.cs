using UnityEngine;

public class Fallingobject : MonoBehaviour
{
    public float fallSpeed = 1f;
    public float zigZagSpeed = 2f;
    public float zigZagWidth = 2f;
    private float startX;
    private float rotationSpeed = 10f;
    Coins coins;

    void Start()
    {
        startX = transform.position.x;
        coins = FindFirstObjectByType<Coins>();
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * zigZagSpeed) * zigZagWidth;
        float y = transform.position.y - fallSpeed * Time.deltaTime;
        transform.position = new Vector3(x, y, transform.position.z);
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void ClickMoney()
    {
        coins.ChangeCoins((long)(PlayerDataManager.Coins * 0.05));
        Debug.Log(PlayerDataManager.Coins);
    }
}
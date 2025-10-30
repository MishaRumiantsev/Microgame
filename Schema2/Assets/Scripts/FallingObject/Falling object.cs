using UnityEditor;
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
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

    }

    public void DestroyObject()
    {
        this.gameObject.SetActive(false);
    }

    public void ClickMoney()
    {
        PlayerDataManager.Coins += (long)(PlayerDataManager.Coins * 0.05);
    }
}
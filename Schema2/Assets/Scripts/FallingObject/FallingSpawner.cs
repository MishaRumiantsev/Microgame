using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField]GameObject prefab;
    Vector3 spawnLocation;
    [SerializeField]GameObject locationObject;
    [SerializeField] float spawnCooldown;
    private bool isThereFallingObject = false;
    public Canvas targetCanvas;

    private float spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = spawnCooldown;
        spawnLocation = locationObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else if (spawnTime <= 0 && isThereFallingObject == false)
        {
            GameObject newUI = Instantiate(prefab, targetCanvas.transform);
            spawnTime = spawnCooldown;
        }
    }
}

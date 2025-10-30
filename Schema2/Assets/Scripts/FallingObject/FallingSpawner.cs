using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField]GameObject prefab;
    Vector3 spawnLocation;
    [SerializeField]GameObject locationObject;
    [SerializeField] float spawnCooldown;
    [SerializeField] Sprite sprite;
    private bool isThereFallingObject = false;

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
        if (isThereFallingObject)
        {
            isThereFallingObject = false;
        }
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else if (spawnTime <= 0 && isThereFallingObject == false)
        {

            prefab.GetComponent<SpriteRenderer>().sprite = sprite;
            prefab.transform.position = spawnLocation;
            prefab.transform.rotation= Quaternion.identity;
            prefab.SetActive(true);
            spawnTime = spawnCooldown;
            isThereFallingObject=true;
        }
    }
}

using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject finish;

    private float timer;
    private float spawnCount = 0;
    private float maxBuildings = 5;

    private void Start()
    {
        SpawnBuilding();
    }
    private void Update()
    {
        if (spawnCount == maxBuildings)
        {
            return; // zo laat ik hem stoppen als hij 10 buildinsg heeft ingespawnt
        }
        if (timer > maxTime)
        {
            SpawnBuilding();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    private void SpawnBuilding()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject buildings = Instantiate(building, spawnPosition, Quaternion.identity);
        Destroy(buildings, 10f);
        spawnCount++;
        if (spawnCount >= maxBuildings)
        {
            Vector3 finishPosition = spawnPosition + new Vector3(2f, 0, 0);
            Instantiate(finish, finishPosition, Quaternion.identity);
            Debug.Log("finish inspawnedn");
        }
    }
}

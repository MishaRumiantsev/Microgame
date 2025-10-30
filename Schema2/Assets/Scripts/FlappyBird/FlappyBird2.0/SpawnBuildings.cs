using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float heightRange;
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject finish;

    private float timer;
    private void Start()
    {
        SpawnBuilding();
    }
    private void Update()
    {
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
        //De spawn positie van de building, random range als de hoogte waarmee hij random kan spawnen zodat het level anders is.
        GameObject buildings = Instantiate(building, spawnPosition, Quaternion.identity);
        //Dit spawned de buildings die ik hiervoor plaats heb gegeven in de wereld.
        Destroy(buildings, 10f); //Maak buiding kapot
    }
}

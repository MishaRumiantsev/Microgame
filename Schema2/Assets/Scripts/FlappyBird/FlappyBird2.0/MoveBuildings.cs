using UnityEngine;

public class MoveBuildings : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

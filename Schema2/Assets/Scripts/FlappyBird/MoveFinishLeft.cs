using UnityEngine;

public class MoveFinishLeft : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Destroy(gameObject, 10f);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
}

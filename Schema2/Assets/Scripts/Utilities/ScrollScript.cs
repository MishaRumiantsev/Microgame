using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    // 0 = naar onder
    // 1 = naar boven
    [SerializeField] int position;
    void Start()
    {
        GetComponent<ScrollRect>().verticalNormalizedPosition = position;
    }
}

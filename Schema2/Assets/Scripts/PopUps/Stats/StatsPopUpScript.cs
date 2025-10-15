using TMPro;
using UnityEngine;

public class StatsPopUpScript : MonoBehaviour
{
    public static StatsPopUpScript Instance { get; private set; }

    [SerializeField] TextMeshProUGUI totalCoinsText;

    private void Awake()
    {
        // Ensures only one StatsPopUpScript exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
}

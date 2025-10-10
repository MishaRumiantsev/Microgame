using UnityEngine;

public class ButtonControlAchievement : MonoBehaviour
{
    public bool AchievementActive = false;

    // Deze functie wordt aangeroepen als de knop wordt geklikt
    public void SetActiveTrue()
    {
        AchievementActive = true;
        Debug.Log("De bool is nu actief!");
    }
}

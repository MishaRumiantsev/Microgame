using UnityEngine;

public class AchievementPopUp : MonoBehaviour
{
    public GameObject popupPanel;

    // Toon de pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // Verberg de pop-up
    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}

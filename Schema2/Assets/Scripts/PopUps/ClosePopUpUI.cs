using UnityEngine;

/// <summary>
/// This script is attatched to the pop up.
/// It closes the pop up when the close button is clicked.
/// </summary>

public class ClosePopUp : MonoBehaviour
{
    public void ClosePopUpButton()
    {
        Debug.Log("Close Pop-Up Button Clicked");
        PopUpManagerUI.Instance.CloseCurrentPopUp();
    }
}

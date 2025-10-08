using UnityEngine;

public class ClosePopUp : MonoBehaviour
{
    public void ClosePopUpButton()
    {
        Debug.Log("Close Pop-Up Button Clicked");
        PopUpManager.Instance.CloseCurrentPopUp();
    }
}

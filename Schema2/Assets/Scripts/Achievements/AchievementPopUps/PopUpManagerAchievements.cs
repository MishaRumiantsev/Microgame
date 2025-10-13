using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
public class PopUpManagerAchievements : MonoBehaviour
{
    //[SerializeField] private GameObject popupPanel;
    [SerializeField] private float displayTime = 2f;
    [SerializeField] private TextMeshProUGUI popupTitle;
    [SerializeField] private TextMeshProUGUI popupDescription;
    [SerializeField] private GameObject popupPanel;
    public RectTransform outOfScreenPosition;

    public RectTransform popUpTitle;
    public RectTransform popUpDescription;
    public RectTransform popupPanelMoveable;
    void Start()
    {
        popupPanel.SetActive(false);
        popupTitle.text = "";
        popupDescription.text = "";
    }

   public void ShowPopup(string title, string description)
    {
        popupTitle.text = title;
        popupDescription.text = description;
        popupPanel.SetActive(true);
        CancelInvoke(nameof(HidePopup)); //cancelt de timer als deze nog loopt. (Voorkomen dat je meerdere timers start)
        Invoke(nameof(HidePopup), displayTime); //Soort timer, display time kan je aangeven zodat hij 2 seconden blijft
    }

    private void HidePopup()
    {
        MoveToOutOfScreen();
        //popupPanel.SetActive(false);
        //popupTitle.text = "";
        //popupDescription.text = "";
    }

    public void MoveToOutOfScreen()
    {
        Vector2 targetPos = outOfScreenPosition.anchoredPosition;
        popUpTitle.anchoredPosition = targetPos;
        popUpDescription.anchoredPosition = targetPos;
        popupPanelMoveable.anchoredPosition = targetPos;
    }
}

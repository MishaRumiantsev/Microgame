using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
public class PopUpManagerAchievements : MonoBehaviour
{
    [SerializeField] private float displayTime = 5f;
    [SerializeField] private TextMeshProUGUI popupTitle;
    [SerializeField] private TextMeshProUGUI popupDescription;
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject popupButton;
    public AudioSource AchievementSound;
    //Alle variabelen hierboven die ik nodig heb zodat de achievement werkt
    void Start()
    {
        popupPanel.SetActive(false);
        popupButton.SetActive(false);
        popupTitle.text = "";
        popupDescription.text = "";
    }

   public void ShowPopup(string title, string description)
   {
       AchievementSound.Play();
        //Speelt achivement sound
       popupTitle.text = title;
       popupDescription.text = description;
        //Popupdescription wordt opgeslagen
       popupPanel.SetActive(true);
       popupButton.SetActive(true);
       CancelInvoke(nameof(HidePopup)); //cancelt de timer als deze nog loopt. (Voorkomen dat je meerdere timers start)
       Invoke(nameof(HidePopup), displayTime); //Soort timer, display time kan je aangeven zodat hij 2 seconden blijft
   }

    private void HidePopup()
    {
        popupButton.SetActive(false);
        popupPanel.SetActive(false);
        popupTitle.text = "";
        popupDescription.text = "";
    }
    public void OnButtonClick()
    {
        HidePopup();
    }
}

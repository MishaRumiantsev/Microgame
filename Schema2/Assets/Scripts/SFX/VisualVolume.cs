using UnityEngine;
using UnityEngine.UI;

public class VisualVolume : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private AudioMixManager audioMix;

    private void Start()
    {
        audioMix = Object.FindFirstObjectByType<AudioMixManager>();
    }

    private void OnEnable()
    {
        // essential guard: avoid null reference if PlayerDataManager not initialized
        if (PlayerDataManager.Instance == null) return;

        float sfx = Mathf.Clamp01(PlayerDataManager.sfxVolume);
        float music = Mathf.Clamp01(PlayerDataManager.musicVolume);

        if (audioMix != null)
        {
            if (sfxSlider != null)
            {
                sfxSlider.onValueChanged.RemoveListener(audioMix.SetSfxVolume);
                sfxSlider.value = sfx;
                sfxSlider.onValueChanged.AddListener(audioMix.SetSfxVolume);
            }

            if (musicSlider != null)
            {
                musicSlider.onValueChanged.RemoveListener(audioMix.SetMusicVolume);
                musicSlider.value = music;
                musicSlider.onValueChanged.AddListener(audioMix.SetMusicVolume);
            }
        }
        else
        {
            // If you don't want this branch, ensure AudioMixManager exists in the scene and is found in Start.
            if (sfxSlider != null) sfxSlider.value = sfx;
            if (musicSlider != null) musicSlider.value = music;
        }
    }

    // Buttons save/reset/get money functionality
    public void SaveButton()
    {
        PlayerDataManager.Instance.SavePlayerData();
    }

    public void ResetButton()
    {
        PlayerDataManager.Instance.DeleteAllPlayerData();
    }
}
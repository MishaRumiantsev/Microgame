using UnityEngine;
using UnityEngine.Audio;

public class AudioMixManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    // linear volume values [0..1]
    float currentSfxVolume = 1f;
    float currentMusicVolume = 1f;

    void Start()
    {
        // read current mixer dB values (may be set in the AudioMixer asset)
        audioMixer.GetFloat("sfxVolume", out float sfxDbFromMixer);
        audioMixer.GetFloat("musicVolume", out float musicDbFromMixer);

        float mixerLinearSfx = DbToLinear(sfxDbFromMixer);
        float mixerLinearMusic = DbToLinear(musicDbFromMixer);

        if (PlayerDataManager.Instance != null)
        {
            // prefer saved linear values (clamped). If saved are effectively uninitialized (near 0),
            // fall back to the mixer values loaded from the AudioMixer asset.
            currentSfxVolume = Mathf.Clamp01(PlayerDataManager.sfxVolume);
            currentMusicVolume = Mathf.Clamp01(PlayerDataManager.musicVolume);

            if (currentSfxVolume <= 0.0001f && mixerLinearSfx > 0.0001f)
                currentSfxVolume = mixerLinearSfx;
            if (currentMusicVolume <= 0.0001f && mixerLinearMusic > 0.0001f)
                currentMusicVolume = mixerLinearMusic;
        }
        else
        {
            // PlayerDataManager not ready — use mixer values
            currentSfxVolume = mixerLinearSfx;
            currentMusicVolume = mixerLinearMusic;
        }

        // apply to mixer
        audioMixer.SetFloat("sfxVolume", LinearToDb(currentSfxVolume));
        audioMixer.SetFloat("musicVolume", LinearToDb(currentMusicVolume));

        // persist back into PlayerDataManager if available
        if (PlayerDataManager.Instance != null)
        {
            PlayerDataManager.sfxVolume = currentSfxVolume;
            PlayerDataManager.musicVolume = currentMusicVolume;
        }
    }

    // Called by UI sliders with values 0..1
    public void SetSfxVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        audioMixer.SetFloat("sfxVolume", LinearToDb(volume));
        currentSfxVolume = volume;

        if (PlayerDataManager.Instance != null)
        {
            PlayerDataManager.sfxVolume = volume;
            PlayerDataManager.Instance.SavePlayerData();
        }
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        audioMixer.SetFloat("musicVolume", LinearToDb(volume));
        currentMusicVolume = volume;

        if (PlayerDataManager.Instance != null)
        {
            PlayerDataManager.musicVolume = volume;
            PlayerDataManager.Instance.SavePlayerData();
        }
    }

    // helper: convert decibels to linear (0..1)
    private float DbToLinear(float db)
    {
        // inverse of dB = 20 * log10(linear)
        return Mathf.Pow(10f, db / 20f);
    }

    // helper: convert linear (0..1) to decibels; handle zero safely (mute)
    private float LinearToDb(float linear)
    {
        if (linear <= 0.0001f) // treat as muted
            return -80f;
        return Mathf.Log10(linear) * 20f;
    }
}
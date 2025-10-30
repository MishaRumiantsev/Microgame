using System.Reflection.Emit;
using UnityEngine;

public class SfxManager : MonoBehaviour
{


    //-------------ALL AUDIO CLIPS-----------------
    [Header("SFX")]
    [Space(10)]

    [SerializeField] public AudioClip buttonSfx;
    [SerializeField] public AudioClip upgradeSfx;
    [SerializeField] public AudioClip popUpOpen;
    [SerializeField] public AudioClip popUpClose;
    [SerializeField] public AudioClip prestigeSfx;

    [SerializeField] public AudioClip[] sellpointAmbience;

    [SerializeField] public AudioClip[] flappyFlaps;
    [SerializeField] public AudioClip flappyDead;
    //---------------------------------------------

    public static SfxManager instance;


    [Space(10)]
    [SerializeField] private AudioSource audioSourcePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySfxClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn gameObject
        AudioSource audioSource = Instantiate(audioSourcePrefab, spawnTransform.position, Quaternion.identity);

        //assign audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play audioClip
        audioSource.Play();

        //get lenght of audioClip
        float clipLength = audioSource.clip.length;

        //destroy gameObject after clip is finished playing
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSfxClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //assign a random index
        int rand = Random.Range(0, audioClip.Length);

        //spawn gameObject
        AudioSource audioSource = Instantiate(audioSourcePrefab, spawnTransform.position, Quaternion.identity);

        //assign audioClip
        audioSource.clip = audioClip[rand];

        //assign volume
        audioSource.volume = volume;

        //play audioClip
        audioSource.Play();

        //get lenght of audioClip
        float clipLength = audioSource.clip.length;

        //destroy gameObject after clip is finished playing
        Destroy(audioSource.gameObject, clipLength);
    }
}

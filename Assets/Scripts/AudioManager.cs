using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------------------AudioSource--------------------")]

    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource _SFX;

    [Header("--------------------AudioClip--------------------")]
    public AudioClip MusicBG;
    public AudioClip JumpSFX;
    public AudioClip RunSFX;
    public AudioClip CollectSFX;
    public AudioClip WinSFX;
    public static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        Music.clip = MusicBG;
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SFX(AudioClip sfx)
    {
        _SFX.PlayOneShot(sfx);
    }
}

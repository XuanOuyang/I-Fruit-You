using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip MainMenu;
    public AudioClip HappierTheme;
    public AudioClip MamaInTheUS;
    public AudioClip PaceQuickens;
    public AudioClip SadderTheme;
    public AudioClip Ending;
    public AudioClip AirplaneBelt;
    public AudioClip CarDoorSlam;
    public AudioClip DoorOpen;
    public AudioClip DoorSlamInstant;
    public AudioClip PlateOnTable;
    public AudioClip MovePlane;
    public AudioClip PickUpPiece;
    public AudioClip PlacePiece;

    private void Start()
    {
        musicSource.clip = MainMenu;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    //To call specific audio clip:
    //Audio Manager audioManager;
    //private void Awake()
    //{
    //  audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //}

    //audioManager.PlaySFX(audioManager.PickUpPiece);
}

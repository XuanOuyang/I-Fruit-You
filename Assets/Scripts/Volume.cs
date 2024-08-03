using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider MasterVol;
    public AudioMixer MainAudioMixer;

    public void ChangeMasterVolume()
    {
        MainAudioMixer.SetFloat("MasterVol", MasterVol.value);
    }
}

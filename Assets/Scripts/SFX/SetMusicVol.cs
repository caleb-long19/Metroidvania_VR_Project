using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVol : MonoBehaviour
{
    // Get AudioMixer called Mixer
    public AudioMixer musicmixer;

    public void SetLevelMusic(float sliderValue)
    {
        // The music mixer is set to a float value and can be altered on the volume slider
        musicmixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20); 
    }
}

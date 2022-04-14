using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSFXVol : MonoBehaviour
{
    public AudioMixer sfxmixer; // get AudioMixer called Mixer

    public void SetLevelSFX(float sliderValue)
    {
        sfxmixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20); // The SFX mixer is set to a float value and can be altered on the volume slider
    }
}

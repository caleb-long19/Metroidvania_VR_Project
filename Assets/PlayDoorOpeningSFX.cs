using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorOpeningSFX : MonoBehaviour
{
    public AudioSource audioData;

    private void OnEnable()
    {

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }

}

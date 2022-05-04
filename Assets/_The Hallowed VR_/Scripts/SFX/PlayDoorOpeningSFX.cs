using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorOpeningSFX : MonoBehaviour
{
    public AudioSource doorOpeningSFX;

    private void OnEnable()
    {
        //This script is enabled in the door animation

        //Get the audio source component on the game object
        doorOpeningSFX = GetComponent<AudioSource>();

        //Play door opening sfx
        doorOpeningSFX.Play(0);

        Debug.Log("Door Openining SFX Is Playing");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class AngelinaNPC : MonoBehaviour
{
    //Unity References

    // GameObject for Angelina NPC Dialog Box
    public GameObject DialogBoxAngelina;

    //Angelina Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;
    public GameObject DialogWarning;

    //Bools
    private bool angelinaIntroduced = false;

    //Angelina SFX
    public AudioSource angelinaSFX;

    //Steam VR Input System
    public SteamVR_Action_Boolean talkNPC;


    void Start()
    {
        #region Set Bools to True or False when Game Begins
        //NPC Dialog Box is equal to False
        DialogBoxAngelina.SetActive(false);

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        DialogWarning.SetActive(false);
        #endregion
    }


    void Update()
    {
        angelinaDialogueSelection();
    }


    public void angelinaDialogueSelection()
    {
        //If player has talked to the npc once, load the next piece of dialogue
        if (angelinaIntroduced == true)
        {
            DialogIntroduction.SetActive(false);
            DialogWarning.SetActive(true);
        }
    }


    public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        //Check if player has collided with NPC and if they are pressing the A button
        if (collision.tag == "Player" && talkNPC.stateDown)
        {
            // Play the npc sfx, hide the interact text and display the dialogue box
            angelinaSFX.Play();
            HideText.SetActive(false);
            DialogBoxAngelina.SetActive(true);

            Debug.Log("Collided with Npc");
        }

        #endregion
    }

    public void OnTriggerExit(Collider collision)
    {
        // Reactivate the interact text and disable the dialogue box
        HideText.SetActive(true);
        DialogBoxAngelina.SetActive(false);
        angelinaIntroduced = true;
    }
}


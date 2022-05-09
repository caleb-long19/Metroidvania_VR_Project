using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ObradiusNPC : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxObradius; // GameObject for Obradius NPC Dialog Box

    //Obradius Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;
    public GameObject DialogSuperStrength;
    public GameObject DialogGrappleHook;

    //Puzzle Items
    public GameObject SuperStrength;
    public GameObject GrappleHook;

    //Obradius SFX
    public AudioSource ObradiusSFX;

    //Steam VR Input System
    public SteamVR_Action_Boolean talkNPC;

    void Start()
    {
        #region Set Bools to True or False when Game Begins
        //NPC Dialog Box is equal to False
        DialogBoxObradius.SetActive(false);

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        DialogSuperStrength.SetActive(false);
        DialogGrappleHook.SetActive(false);
        #endregion
    }


    void Update()
    {
        ObradiusDialogueSelection();
    }


    public void ObradiusDialogueSelection()
    {
        // If Player picks up the Strength Object, continue to next dialogue
        if (SuperStrength.activeInHierarchy == false)
        {
            DialogIntroduction.SetActive(false);
            DialogSuperStrength.SetActive(true);
        }
        //If the player has colected the Grapple Hook, continue to next dialogue
        if (GrappleHook.activeInHierarchy == false)
        {
            DialogSuperStrength.SetActive(false);
            DialogGrappleHook.SetActive(true);
        }
    }


    public void OnTriggerStay(Collider collision)
    {
        //Check if player has collided with NPC and if they are pressing the A button
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player" && talkNPC.stateDown)
        {
            //Play sound effect
            ObradiusSFX.Play();

            //Hide the interact with npc text and display the npc dialogue box
            HideText.SetActive(false);
            DialogBoxObradius.SetActive(true);

            Debug.Log("Collided with Npc");
        }
        #endregion
    }

    public void OnTriggerExit(Collider collision)
    {
        //Close Dialogue Box when player leaves the collision zone
        HideText.SetActive(true);
        DialogBoxObradius.SetActive(false);
    }
}

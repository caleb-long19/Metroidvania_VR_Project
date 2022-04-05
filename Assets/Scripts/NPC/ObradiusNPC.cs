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

    public SteamVR_Action_Boolean talkNPC;

    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxObradius.SetActive(false); //NPC Dialog Box is equal to False

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
        if (SuperStrength.activeInHierarchy == false) // If Player picks up the Strength Object, continue dialogue
        {
            DialogIntroduction.SetActive(false);
            DialogSuperStrength.SetActive(true);
        }
        if (GrappleHook.activeInHierarchy == false) //If the player has colected the Grapple Hook, continue dialogue
        {
            DialogSuperStrength.SetActive(false);
            DialogGrappleHook.SetActive(true);
        }
    }


    public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player" && talkNPC.stateDown)
        {
            ObradiusSFX.Play();
            HideText.SetActive(false);
            Debug.Log("Collided with Npc");
            DialogBoxObradius.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
        }
        #endregion
    }

    public void OnTriggerExit(Collider collision)
    {
        HideText.SetActive(true);
        DialogBoxObradius.SetActive(false);
    }
}

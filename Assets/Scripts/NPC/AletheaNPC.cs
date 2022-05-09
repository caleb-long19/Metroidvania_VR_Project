using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class AletheaNPC : MonoBehaviour
{
    //Unity References
    // GameObject for Alethea NPC Dialog Box
    public GameObject DialogBoxAlethea;

    //Alethea Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;

    //Steam VR Input System
    public SteamVR_Action_Boolean talkNPC;

    void Start()
    {
        #region Set Bools to True or False when Game Begins
        //NPC Dialog Box is equal to False
        DialogBoxAlethea.SetActive(false);

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        #endregion
    }

    public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player" && talkNPC.stateDown) //Check if player has collided with NPC and if they are pressing the A button
        {
            // Display NPC Dialog Box when Player Collides with NPC and hide interact text
            HideText.SetActive(false);
            DialogBoxAlethea.SetActive(true);

            Debug.Log("Collided with Npc");
        }
        #endregion
    }

    public void OnTriggerExit(Collider collision)
    {
        //Enable interact text and disable dialogue box
        HideText.SetActive(true);
        DialogBoxAlethea.SetActive(false);
    }
}


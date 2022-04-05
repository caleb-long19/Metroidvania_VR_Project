using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class AletheaNPC : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxAlethea; // GameObject for Alethea NPC Dialog Box

    //Alethea Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;

    public SteamVR_Action_Boolean talkNPC;

    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxAlethea.SetActive(false); //NPC Dialog Box is equal to False

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        #endregion
    }

    public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player" && talkNPC.stateDown)
        {
            HideText.SetActive(false);
            Debug.Log("Collided with Npc");
            DialogBoxAlethea.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
        }
        #endregion
    }

    public void OnTriggerExit(Collider collision)
    {
        HideText.SetActive(true);
        DialogBoxAlethea.SetActive(false);
    }
}


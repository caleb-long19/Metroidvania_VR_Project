using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AletheaNPC : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxAlethea; // GameObject for Alethea NPC Dialog Box

    //Alethea Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;


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
        if (collision.tag == "Player")
        {
            HideText.SetActive(false);
            Debug.Log("Collided with Npc");
            DialogBoxAlethea.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
        }

        HideText.SetActive(true);
        #endregion
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObradiusNPC : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxObradius; // GameObject for Obradius NPC Dialog Box

    //Obradius Text Boxes
    public GameObject HideText;
    public GameObject DialogIntroduction;
    public GameObject DialogIntroduction_Part2;
    public GameObject DialogSuperStrength;
    public GameObject DialogGrappleHook;


    //Puzzle Items
    public GameObject SuperStrength;
    public GameObject GrappleHook;


    //Obradius SFX
    public AudioSource ObradiusSFX;


    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxObradius.SetActive(false); //NPC Dialog Box is equal to False

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        DialogIntroduction_Part2.SetActive(false);
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
            DialogIntroduction_Part2.SetActive(false);
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
        if (collision.tag == "Player")
        {
            HideText.SetActive(false);
            Debug.Log("Collided with Npc");
            DialogBoxObradius.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
            ObradiusSFX.Play(0); // Play NPC SFX
        }
        #endregion
    }
}

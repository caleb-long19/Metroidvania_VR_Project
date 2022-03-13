using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AngelinaNPC : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxAngelina; // GameObject for Angelina NPC Dialog Box

    //Angelina Text Boxes
    public GameObject DialogIntroduction;
    public GameObject DialogWarning;

    //Bools
    public bool angelinaIntroduced = false;

    //Angelina SFX
    public AudioSource angelinaSFX;


    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxAngelina.SetActive(false); //NPC Dialog Box is equal to False

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
        if (angelinaIntroduced == true)
        {
            DialogIntroduction.SetActive(false);
            DialogWarning.SetActive(true);
        }
    }


    public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player")
        {
            Debug.Log("Collided with Npc");
            DialogBoxAngelina.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
            angelinaSFX.Play(0); // Play NPC SFX
        }

        angelinaIntroduced = true;
        #endregion
    }
}


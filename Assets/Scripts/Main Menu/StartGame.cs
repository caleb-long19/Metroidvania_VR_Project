using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

    public Interactable interactable;

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            //If object has been grabbed, load the main game scene
            SceneManager.LoadScene("HallowedScene");

            Debug.Log("Item has been grabbed");
        }
    }
}


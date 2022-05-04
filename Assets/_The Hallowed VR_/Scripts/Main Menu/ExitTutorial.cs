using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class ExitTutorial : MonoBehaviour
{
    public Interactable interactable;

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            // If player has grabbed the main menu object, load the main menu scene
            SceneManager.LoadScene("HVRMainMenu");

            Debug.Log("Item has been grabbed");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public Interactable interactable;

    // Update is called once per frame
    void Update()
    {
        // if player has grabbed the exit object, close the game
        if (interactable.attachedToHand != null)
        {
            Application.Quit();
        }
    }
}
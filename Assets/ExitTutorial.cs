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
            Debug.Log("Item has been grabbed");
            SceneManager.LoadScene("HVRMainMenu");
        }
    }
}
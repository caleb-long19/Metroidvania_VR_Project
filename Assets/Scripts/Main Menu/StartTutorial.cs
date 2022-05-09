using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class StartTutorial : MonoBehaviour
{
    public Interactable interactable;

    // Update is called once per frame
    void Update()
    {
        //Check if game object has been grabbed
        if (interactable.attachedToHand != null)
        {
            //Load the tutorial scene
            SceneManager.LoadScene("Tutorial");
            Debug.Log("Item has been grabbed");
        }
    }
}

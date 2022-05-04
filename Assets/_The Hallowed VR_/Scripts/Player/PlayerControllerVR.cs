using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerVR : MonoBehaviour
{

    #region singleton

    public static PlayerControllerVR instance;

    public GameObject GrappleHookPickup;
    public GameObject GrappleHook;

    public GameObject Player;

    void Awake()
    {
        //Singleton to store the player game object
        instance = this;
        GrappleHook.SetActive(false);
    }

    #endregion

    private void Update()
    {
        //Disable the grapple hook weapon on the player, if the ability has not been pickup up
        if (!GrappleHookPickup.activeInHierarchy)
        {
            GrappleHook.SetActive(true);
        }
    }
}

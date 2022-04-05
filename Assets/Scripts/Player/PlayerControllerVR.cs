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

    void Awake()
    {
        instance = this;
        GrappleHook.SetActive(false);
    }

    #endregion

    public GameObject Player;

    private void Update()
    {
        if (!GrappleHookPickup.activeInHierarchy)
        {
            GrappleHook.SetActive(true);
        }
    }
}

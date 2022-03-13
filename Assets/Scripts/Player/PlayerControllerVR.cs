using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerVR : MonoBehaviour
{

    #region singleton

    public static PlayerControllerVR instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Player;

}

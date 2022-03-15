using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuperStrength : MonoBehaviour
{
    public GameObject superStrength;

    public Type XRGrabInteractable { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (superStrength.activeInHierarchy == false)
        {
            this.GetComponent<XRGrabInteractable>().enabled = true;
        }
        else
        {
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
    }
}

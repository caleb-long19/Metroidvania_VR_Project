using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SuperStrength : MonoBehaviour
{
    public GameObject superStrength;
    public Collider stopTeleport;

    public Type Interactable { get; private set; }

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.WakeUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (superStrength.activeInHierarchy == false)
        {
            this.GetComponent<Interactable>().enabled = true;
            rb.isKinematic = false;
            stopTeleport.enabled = false;
        }
        else
        {
            this.GetComponent<Interactable>().enabled = false;
            rb.isKinematic = true;
        }
    }
}

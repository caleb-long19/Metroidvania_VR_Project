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

    public Rigidbody rigidBody;

    void Start()
    {
        //Get rigidbody component of game object
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.WakeUp();
    }

    // Update is called once per frame
    void Update()
    {
        //If super strength has been acquired
        if (superStrength.activeInHierarchy == false)
        {
            //Enable the interactive component on the game object and enable physics
            this.GetComponent<Interactable>().enabled = true;
            rigidBody.isKinematic = false;

            //Disable the collider that prevents player from teleporting to past the rock
            stopTeleport.enabled = false;
        }
        else
        {
            //Disable interactivity and physics if the ability hasn't been pickup up
            this.GetComponent<Interactable>().enabled = false;
            rigidBody.isKinematic = true;
        }
    }
}

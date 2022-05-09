using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PhysicsManager : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve the rigidbody and interactable component of the game object
        rigidbody.GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();

        //Enable kinematic
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If the object has been interacted with, enable the physics
        if (interactable.attachedToHand != null)
        {
            rigidbody.isKinematic = false;
        }
    }
}

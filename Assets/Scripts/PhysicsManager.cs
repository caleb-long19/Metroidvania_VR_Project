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
        rigidbody.GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            rigidbody.isKinematic = false;
        }
    }
}

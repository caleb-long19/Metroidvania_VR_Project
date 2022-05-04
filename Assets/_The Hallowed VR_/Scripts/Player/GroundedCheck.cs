using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public bool isGroundedCheck;

    private CharacterController characterController;
    public Collider playerCollider;
    private Rigidbody playerPhysics;

    private void Awake()
    {
        //Find the character controller and rigidbody components on the player game object
        characterController = GetComponent<CharacterController>();
        playerPhysics = GetComponent<Rigidbody>();
    }

    public void OnCollisionStay(Collision collision)
    {
        //If the player is colliding with the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Set grounded to true, disable physics and enable player movement
            isGroundedCheck = true;
            playerPhysics.isKinematic = true;
            characterController.enabled = true;

            //Disable second collider for grapple use
            playerCollider.enabled = false;
        }
        else
        {
            // Set grounded to false, enable physics and disable player movement when grappleis being used
            isGroundedCheck = false;
            playerPhysics.isKinematic = false;
            characterController.enabled = false;

            //Enable second collider for grapple use
            playerCollider.enabled = true;
        }
    }
}

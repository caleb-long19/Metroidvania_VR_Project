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
        characterController = GetComponent<CharacterController>();
        playerPhysics = GetComponent<Rigidbody>();
    }

    public void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGroundedCheck = true;
            playerCollider.enabled = false;
            playerPhysics.isKinematic = true;
            characterController.enabled = true;
        }
        else
        {
            isGroundedCheck = false;
            playerCollider.enabled = true;
            playerPhysics.isKinematic = false;
            characterController.enabled = false;
        }
    }
}

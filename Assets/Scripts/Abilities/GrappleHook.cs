using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class GrappleHook : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleLocation;
    public Transform grappleTip, camera, player;
    private float maxDistance = 100.0f;
    private SpringJoint joint;

    public SteamVR_Action_Boolean fireGrappleHook;
    private Interactable interactable;
    private bool nowFiring = false;

    public AudioSource grappleSFX;

    public float springValue = 8f;
    public float damperValue = 8f;

    public CharacterController characterController;
    public Collider playerCollider;
    public Rigidbody playerPhysics;
    public GroundedCheck groundedCheck;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireGrappleHook[source].stateDown)
            {
                StartGrapple();

                characterController.enabled = false;
                playerPhysics.isKinematic = false;
                playerCollider.enabled = true;


                grappleSFX.Play();
                Debug.Log("Grapple is being fired!");
            }
            else if (fireGrappleHook[source].stateUp)
            {
                StopGrapple();  
                grappleSFX.Stop();

                playerPhysics.isKinematic = false;
                playerCollider.enabled = true;
            }
        }

        Debug.Log("GROUNDED VALUE IS: " + groundedCheck.isGroundedCheck);
    }

    void LateUpdate()
    {
        drawGrapple();
    }

    void StartGrapple()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleLocation))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.6f;
            joint.minDistance = distanceFromPoint * 0.1f;

            joint.spring = springValue;
            joint.damper = damperValue;

            lr.positionCount = 2;
        }
    }

    void drawGrapple()
    {
        if (!joint) return;
        lr.SetPosition(0, grappleTip.position);
        lr.SetPosition(1, grapplePoint);

    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}

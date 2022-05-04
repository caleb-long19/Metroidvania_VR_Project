using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class GrappleHook : MonoBehaviour
{
    //Transformation, layermask, and spring values
    public Transform grappleTip, camera, player;
    public LayerMask whatIsGrappleLocation;
    private Vector3 grapplePoint;
    private SpringJoint joint;

    //Audio
    public AudioSource grappleSFX;

    //Grapple values
    private float maxDistance = 100.0f;
    public float springValue = 8f;
    public float damperValue = 8f;
    private bool nowFiring = false;

    //Control player components
    public CharacterController characterController;
    public Collider playerCollider;
    public Rigidbody playerPhysics;
    public GroundedCheck groundedCheck;

    //SteamVR controller input
    public SteamVR_Action_Boolean fireGrappleHook;

    //Interactable component on Grapple
    private Interactable interactable;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        //Retrieve the components on the grapple hook
        lineRenderer = GetComponent<LineRenderer>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if grapple hook is equipped
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            //Check if the player is being pressed
            if (fireGrappleHook[source].stateDown)
            {
                //Call methid
                StartGrapple();

                //Disable player movement, enable physics and enable second collider
                characterController.enabled = false;
                playerPhysics.isKinematic = false;
                playerCollider.enabled = true;

                //Play sfx
                grappleSFX.Play();

                Debug.Log("Grapple is being fired!");
            }
            //Check if trigger is not being pressed
            else if (fireGrappleHook[source].stateUp)
            {
                //Cancel the grapple hook
                StopGrapple();  

                //Disable sfx
                grappleSFX.Stop();

                //Disable player physics and enable player controller
                playerPhysics.isKinematic = false;
                playerCollider.enabled = true;
            }
        }

        Debug.Log("GROUNDED VALUE IS: " + groundedCheck.isGroundedCheck);
    }

    void LateUpdate()
    {
        //Late update to draw method, the line being rendered will look disconnected from the grapple hook else
        drawGrapple();
    }

    void StartGrapple()
    {
        //Used to detect a collision with an object
        RaycastHit hit;

        //Fire a raycast based on the looking direction of the player camera, check for collision, set distance of raycast, check the layer mask of the collided object
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleLocation))
        {
            //store transform values of the raycast collision point
            grapplePoint = hit.point;

            // join keeps the rigidbody apart, simulating an elastic band that is pulling two anchor points together e.g. player and the grapple point
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            //Store the distance between the player and the grapple hit point
            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //calculate the min/max distance of the player from the grapple point
            joint.maxDistance = distanceFromPoint * 0.6f;
            joint.minDistance = distanceFromPoint * 0.1f;

            //Strength of the spring e.g. how fast the player will move when they fire the grapple
            joint.spring = springValue;

            //Reduce spring amount when grapple is active
            joint.damper = damperValue;

            //No of Vertices - display the line
            lineRenderer.positionCount = 2;
        }
    }

    void drawGrapple()
    {
        if (!joint) return;

        //Set the line renderer from the tip of grapple gun and the point the raycast hits
        lineRenderer.SetPosition(0, grappleTip.position);
        lineRenderer.SetPosition(1, grapplePoint);

    }

    void StopGrapple()
    {
        //Destroy line renderer vertices and joint
        lineRenderer.positionCount = 0;
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

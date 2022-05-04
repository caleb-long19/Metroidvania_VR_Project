using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovementController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1.0f;
    private CharacterController characterController;

    private void Start()
    {
        //Get the character controller component on the Player
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Store the dir of the vr headset
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));

        //Move is linked to the character controller, most functionality is done for, speed is used to determine the movement speed of the player and deltatime to make the game frame idependent (regardless of the fps, the game will be executed at the same speed)
        //ProjectOnPlane is used to make sure the direction is on the horizontal plane
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
    }

}

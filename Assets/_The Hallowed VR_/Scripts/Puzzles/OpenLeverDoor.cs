using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLeverDoor : MonoBehaviour
{
    public GameObject leverObject;
    private float leverXposition;
    public Animator OpenFirstLeverDoor;


    // Update is called once per frame
    void Update()
    {
        //Check if the transform values on the game object are being changed
        if (transform.hasChanged)
        {
            //Store the x position of the lever game object
            leverXposition = leverObject.transform.localRotation.eulerAngles.x;
            leverXposition = (leverXposition > 180) ? leverXposition - 360 : leverXposition;

            // Check if lever x transform value
            if (leverXposition >= 35)
            {
                //Play the door opening animation
                OpenFirstLeverDoor.SetBool("LeverActivated", true);
                Debug.Log("LEVER IS WORKING!");
            }
        }
    }
}

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
        if (transform.hasChanged)
        {
            leverXposition = leverObject.transform.localRotation.eulerAngles.x;
            leverXposition = (leverXposition > 180) ? leverXposition - 360 : leverXposition;

            if (leverXposition >= 35)
            {

                Debug.Log("LEVER IS WORKING!");
                OpenFirstLeverDoor.SetBool("LeverActivated", true);
            }
        }
    }
}

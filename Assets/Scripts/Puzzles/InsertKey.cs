using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertKey : MonoBehaviour
{
    public GameObject missingKey;
    public GameObject arkKey;
    public Animator openDoor;

    void Start()
    {
        //Hide key that is currently in the ark door
        missingKey.SetActive(false);
    }

    void OnCollisionStay(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ark_Key")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Ark Key has been found");

            //Destroy ark key game object and play door opening animation
            Destroy(arkKey);
            missingKey.SetActive(true);
            openDoor.SetBool("OpenDoor", true);
        }
    }
}




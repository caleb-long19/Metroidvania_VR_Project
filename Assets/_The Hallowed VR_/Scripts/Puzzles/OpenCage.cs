using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCage : MonoBehaviour
{
    public GameObject cageLock;
    public GameObject cageKey;
    public Animator OpenCageDoor;

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Cage_Key")
        {
            //When key collides with cage lock, destory the key model and destory the lock on the cage
            Destroy(cageLock);
            Destroy(cageKey);

            //Play the cage door opening animation
            OpenCageDoor.SetBool("CageLocked", true);

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Ark Key has been found");
        }
    }
}

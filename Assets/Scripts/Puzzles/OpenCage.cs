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
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Ark Key has been found");
            Destroy(cageLock);
            Destroy(cageKey);
            OpenCageDoor.SetBool("CageLocked", true);
        }
    }
}

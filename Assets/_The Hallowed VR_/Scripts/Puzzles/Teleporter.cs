using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportLocation;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with portal, teleport player game object to transform/location of other game object
        if (other.tag == "Player")
        {
            Player.transform.position = teleportLocation.transform.position;
        }
    }
}


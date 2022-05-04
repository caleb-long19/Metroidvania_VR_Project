using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportEnd : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //If player collides with the final portal, load the credits scene
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("HVRCredits");

            Debug.Log("TELEPORT TO END");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportEnd : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("TELEPORT TO END");
            SceneManager.LoadScene("HVRCredits");
        }
    }
}

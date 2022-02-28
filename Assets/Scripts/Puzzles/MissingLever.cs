using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingLever : MonoBehaviour
{
    public GameObject disabledLever;
    public GameObject lostLever;

    void Start()
    {
        disabledLever.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Lost_Lever")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
            Destroy(lostLever);
            disabledLever.SetActive(true);
        }
    }
}

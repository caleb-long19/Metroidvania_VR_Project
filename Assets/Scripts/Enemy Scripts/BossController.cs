using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject HallowedPortal;
    public GameObject Boss;

    // Update is called once per frame
    void Update()
    {
        //Check if boss game object exists
        if (Boss == null)
        {
            //Activate the portal game object when boss is killed
            HallowedPortal.SetActive(true);
        }
        else
        {
            //Deactivate the portal game object when boss is alive
            HallowedPortal.SetActive(false);
        }
    }
}


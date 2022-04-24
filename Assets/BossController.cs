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
        if (Boss == null)
        {
            HallowedPortal.SetActive(true);
        }
        else
        {
            HallowedPortal.SetActive(false);
        }
    }
}

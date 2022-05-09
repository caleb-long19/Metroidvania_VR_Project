using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{

    public GameObject VRCamera = null;
    public GameObject weaponbelt;


    // Update is called once per frame
    void Update()
    {
        //Update the position of the weapon holster, rotate object based on the looking direction of the camera
        Vector3 rotation = VRCamera.transform.forward;
        rotation.y = 0f;
        weaponbelt.transform.rotation = Quaternion.LookRotation(rotation);
    }
}

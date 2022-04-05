using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFacePlayer : MonoBehaviour
{
    //Get camera position
    public Transform camera;

    // Update is called once per frame
    void LateUpdate()
    {
        //Face object towards camera position
        transform.LookAt(transform.position + camera.forward);
    }

}

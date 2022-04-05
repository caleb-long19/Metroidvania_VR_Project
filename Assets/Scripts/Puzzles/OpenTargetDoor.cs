using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTargetDoor : MonoBehaviour
{
    public GameObject First_Target;
    public GameObject Second_Target;
    public GameObject Third_Target;
    public GameObject Fourth_Target;
    public Animator TargetDoorOpening;


    void Update()
    {
        if (First_Target == null && Second_Target == null && Third_Target == null && Fourth_Target == null)
        {
            TargetDoorOpening.SetBool("AllTargetsDestroyed", true);
        }

    }

}

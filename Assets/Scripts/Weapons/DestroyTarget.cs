using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip targetSFX;

    void TargetTakesDamage()
    {
        Destroy(this.gameObject);
    }
}

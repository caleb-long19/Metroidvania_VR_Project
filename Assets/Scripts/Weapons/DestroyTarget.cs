using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public AudioClip targetSFX;

    void TargetTakesDamage()
    {
        AudioSource.PlayClipAtPoint(targetSFX, this.gameObject.transform.position);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public AudioClip targetSFX;

    void TargetTakesDamage()
    {
        //When a bolt collides with the targey, destory the target game object and play the target sfx in that position
        AudioSource.PlayClipAtPoint(targetSFX, this.gameObject.transform.position);
        Destroy(this.gameObject);
    }
}

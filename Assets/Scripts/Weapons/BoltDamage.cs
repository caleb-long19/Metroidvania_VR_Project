using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour
{
    public Rigidbody rigidbody;
    public int damage = 2;

    private void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessageUpwards("EnemyTakesDamage", damage, SendMessageOptions.DontRequireReceiver);
        collision.gameObject.SendMessageUpwards("TargetTakesDamage", SendMessageOptions.DontRequireReceiver);
        //rigidbody.isKinematic = true; // stop physics
        //transform.parent = collision.transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject bloodParticles;
    private float depth = 0.30f;

    private PlayerAmmoController playerAmmoController;

    private void Awake()
    {
        rigidbody.GetComponent<Rigidbody>();
        playerAmmoController = GameObject.Find("Player").GetComponent<PlayerAmmoController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessageUpwards("EnemyTakesDamage", playerAmmoController.boltDamage, SendMessageOptions.DontRequireReceiver);
        collision.gameObject.SendMessageUpwards("TargetTakesDamage", SendMessageOptions.DontRequireReceiver);

        if (collision.gameObject.tag == "Enemy")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            Destroy(gameObject);

            Instantiate(bloodParticles, pos, rot);
        }

        //rigidbody.isKinematic = true; // stop physics
        //transform.parent = collision.transform;
    }
}

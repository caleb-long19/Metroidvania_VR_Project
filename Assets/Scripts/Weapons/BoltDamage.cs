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
        //Send a message to the method called "EnemyTakesDamage" in the EnemyAI script, when bolt collides with enemy
        collision.gameObject.SendMessageUpwards("EnemyTakesDamage", playerAmmoController.boltDamage, SendMessageOptions.DontRequireReceiver);

        //Send a message to the method called "TargetTakesDamage" in the DestroyTarget script, when bolt collides with target
        collision.gameObject.SendMessageUpwards("TargetTakesDamage", SendMessageOptions.DontRequireReceiver);

        //Upon collision with an enemy, destroy the bolt and spawn blood particles in the location the crossbow bolt hit
        if (collision.gameObject.tag == "Enemy")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            Destroy(gameObject);

            Instantiate(bloodParticles, pos, rot);
        }
    }
}

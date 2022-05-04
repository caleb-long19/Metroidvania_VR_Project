using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtPlayer : MonoBehaviour
{
    [SerializeField]
    // Integer value for amount of Damage Enemy Deals
    public int damage;

    [SerializeField]
    // Reset time for enemies collider when they attack the Player
    public float resetTime = 2f;

    public Collider boxCollider;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            // When Enemy collides with Player, activate the "TakeEnemyDamage" method inside PlayerHealthController class, and send the amount of damage
            collision.transform.SendMessageUpwards("TakeEnemyDamage", damage, SendMessageOptions.DontRequireReceiver);

            // Disable the enemy collider
            boxCollider.enabled = false;

            // Reset Enemy collider after specific time interval
            Invoke("ResetCollision", resetTime);

            Debug.Log("Player has taken damage!");
        }
    }

    private void ResetCollision()
    {
        // Enable the enemy collider
        boxCollider.enabled = true;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtPlayer : MonoBehaviour
{
    [SerializeField]
    public int damage; // Integer value for amount of Damage Enemy Deals

    [SerializeField]
    public float resetTime = 2f; // Reset time for enemies collider when they attack the Player

    public Collider boxCollider;

    private void OnTriggerEnter(Collider collision)
    {
        collision.transform.SendMessageUpwards("TakeEnemyDamage", damage, SendMessageOptions.DontRequireReceiver);  // When Enemy collides with Player, Player takes damage
        boxCollider.enabled = false; // Enemy collider is equal to false
        Invoke("ResetCollision", resetTime); // Reset Enemy collider after specific time interval
        Debug.Log("Player has taken damage!");

    }

    private void ResetCollision()
    {
        boxCollider.enabled = true; // Resets Enemy collision
    }
}


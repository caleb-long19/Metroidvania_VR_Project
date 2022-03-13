using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public int maxPlayerHealth = 6;
    public int curPlayerHealth;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        curPlayerHealth = maxPlayerHealth;
        playerHealth.SetMaxPlayerHealth(maxPlayerHealth);
    }

    void Update()
    {
        if (curPlayerHealth > maxPlayerHealth)
        {
            curPlayerHealth = maxPlayerHealth;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Health_Bottle")
        {
            if (curPlayerHealth == maxPlayerHealth)
            {
                Debug.Log("Health is FULL");
            }
            else
            {
                Debug.Log("Player has been healed");
                Destroy(collision.gameObject);
                curPlayerHealth += 2;
                playerHealth.SetPlayerHealth(curPlayerHealth);
            }
        }

        if (collision.gameObject.tag == "Health_Upgrade")
        {
            maxPlayerHealth += maxPlayerHealth + 2;
            curPlayerHealth = maxPlayerHealth;
            playerHealth.SetPlayerHealth(curPlayerHealth);
        }
    }

    void TakeDamage(int damage)
    {
        curPlayerHealth -= damage;
        playerHealth.SetPlayerHealth(curPlayerHealth);
    }

    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        curPlayerHealth -= damage; // If Shield is less than or equal to 1, Player can lose Health

        //if the health is less than 0 - reset to 0
        if (curPlayerHealth <= 0)
        {
            curPlayerHealth = 0;
        }
    }

}

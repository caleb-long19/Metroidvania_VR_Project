using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTakeDamage : MonoBehaviour
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
    }

    void TakeDamage(int damage)
    {
        curPlayerHealth -= damage;
        playerHealth.SetPlayerHealth(curPlayerHealth);
    }

}

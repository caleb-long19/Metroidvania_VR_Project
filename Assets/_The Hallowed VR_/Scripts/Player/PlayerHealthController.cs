using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{

    //Ints to store max and current player health
    public int maxPlayerHealth = 6;
    public int curPlayerHealth;

    //Get PlayerHealth Class and a text mesh object to store the number of health (int to string)
    public PlayerHealth playerHealth;
    public TextMeshProUGUI healthNum;

    //Audio sources for player cosuming health
    public AudioSource HealthFullSFX;
    public AudioSource HealthAcquiredSFX;

    // Start is called before the first frame update
    void Start()
    {
        //On start, current health is equal to max
        curPlayerHealth = maxPlayerHealth;

        //Set the health bar slider to the max health value in the PlayerHealth script
        playerHealth.SetMaxPlayerHealth(maxPlayerHealth);
    }

    void Update()
    {

        //Error handling: prevent current health from being greater than max
        if (curPlayerHealth > maxPlayerHealth)
        {
            curPlayerHealth = maxPlayerHealth;
        }

        //If the players health reaches 0, reload scene as they have been killed and reset health
        if (curPlayerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            curPlayerHealth = maxPlayerHealth;
        }

        //Update the players health on their hand by converting max health int to string
        healthNum.text = curPlayerHealth.ToString() + "/" + maxPlayerHealth;

    }

    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        //When player collides with enemy, take away damage int from current player health
        curPlayerHealth -= damage;

        //Update players current health on canvas slider
        playerHealth.SetPlayerHealth(curPlayerHealth);
        Debug.Log("Player has taken damage");
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Check if player collides with an object that has the tag "Health_Bottle
        if (collision.tag == "Health_Bottle")
        {
            //Don't let player consume health, if they are already at max
            if (curPlayerHealth == maxPlayerHealth)
            {
                HealthFullSFX.Play();
                Debug.Log("Health is FULL");
            }
            else
            {
                //If player has less than max health, add 2 to the current health int and play heal sfx
                curPlayerHealth += 2;
                HealthAcquiredSFX.Play();

                //Update the canvas health slider value and destroy the health bottle
                playerHealth.SetPlayerHealth(curPlayerHealth);
                Destroy(collision.gameObject);

                Debug.Log("Player has been healed");
            }
        }

        if (collision.tag == "Health_Upgrade")
        {
            //Play upgrade sound effect
            HealthAcquiredSFX.Play();

            //Increase the max player health by 2
            maxPlayerHealth = maxPlayerHealth + 2;

            //Update current health and make it equal to the new max health
            curPlayerHealth = maxPlayerHealth;
            playerHealth.SetMaxPlayerHealth(maxPlayerHealth);
            playerHealth.SetPlayerHealth(curPlayerHealth);

            //Destory health bottle
            Destroy(collision.gameObject);

            Debug.Log("Item has collided");
        }
    }

    public void UpdateHealth()
    {
        //Update the current and max health values on the canvas health slider
        playerHealth.SetMaxPlayerHealth(curPlayerHealth);
        playerHealth.SetPlayerHealth(maxPlayerHealth);
    }
}

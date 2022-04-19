using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{

    public int maxPlayerHealth = 6;
    public int curPlayerHealth;

    public PlayerHealth playerHealth;
    public TextMeshProUGUI healthNum;

    public AudioSource HealthFullSFX;
    public AudioSource HealthAcquiredSFX;

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

        if (curPlayerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            curPlayerHealth = maxPlayerHealth;
        }

        healthNum.text = curPlayerHealth.ToString() + "/" + maxPlayerHealth;

    }

    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        curPlayerHealth -= damage; // take away damage int from current player health
        playerHealth.SetPlayerHealth(curPlayerHealth);
        Debug.Log("Player has taken damage");
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Health_Bottle")
        {
            if (curPlayerHealth == maxPlayerHealth)
            {
                Debug.Log("Health is FULL");
                HealthFullSFX.Play();
            }
            else
            {
                Debug.Log("Player has been healed");
                curPlayerHealth += 2;
                HealthAcquiredSFX.Play();
                playerHealth.SetPlayerHealth(curPlayerHealth);
                Destroy(collision.gameObject);
            }
        }

        if (collision.tag == "Health_Upgrade")
        {
            Debug.Log("Item has collided");
            HealthAcquiredSFX.Play();

            maxPlayerHealth = maxPlayerHealth + 2;
            curPlayerHealth = maxPlayerHealth;
            playerHealth.SetMaxPlayerHealth(maxPlayerHealth);
            playerHealth.SetPlayerHealth(curPlayerHealth);
            Destroy(collision.gameObject);
        }
    }

    public void UpdateHealth()
    {
        playerHealth.SetMaxPlayerHealth(curPlayerHealth);
        playerHealth.SetPlayerHealth(maxPlayerHealth);
    }
}

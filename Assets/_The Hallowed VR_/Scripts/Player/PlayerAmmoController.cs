using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoController : MonoBehaviour
{
    public int maxAmmo = 50;
    public int boltDamage = 2;
    public int currentAmmo;

    public PlayerAmmo playerAmmo;

    public AudioSource AmmoFullSFX;
    public AudioSource AmmoAcquiredSFX;

    void Start()
    {
        //Set the min ammo and max ammo in the PlayerAmmo class
        playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);
    }

    private void Update()
    {
        //Error handling: If current ammo goes above max, reset to max value
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //If player collides with ammo game object with tag "Ammo"
        if (collision.tag == "Ammo")
        {
            // Prevent ammo from being consumed if ammo is full
            if (currentAmmo == maxAmmo)
            {
                AmmoFullSFX.Play();
                Debug.Log("Player Ammo is full");
            }
            else
            {
                //If ammo is consumed, add 10 to the current ammo count, play sfx, and update the ammo counter on the crossbow
                currentAmmo += 10;
                AmmoAcquiredSFX.Play();
                playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);

                //Destroy game object
                Destroy(collision.gameObject);

                Debug.Log("Ammo has been acquired!");

            }
        }

        //If player collides with game object with tag Ammo_Upgrade
        if (collision.tag == "Ammo_Upgrade")
        {
            //Play sfx
            AmmoAcquiredSFX.Play();

            //Increase the max ammo count by 10, give player more ammo and update the ammo counter on the crossbow
            maxAmmo += 10;
            currentAmmo += 10;
            playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);

            Destroy(collision.gameObject);

            Debug.Log("Ammo Upgrade has collided");
        }

        //If player collides with game object with tag Damage_Upgrade
        if (collision.tag == "Damage_Upgrade")
        {
            AmmoAcquiredSFX.Play();

            //Increase damage a crossbow bolt deals by 2, 
            boltDamage += 2;

            Destroy(collision.gameObject);

            Debug.Log("Damage Upgrade has collided");
        }
    }

    public void UpdateAmmo()
    {
        // Method used to update the ammo count values on the crossbow
        playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);
    }
}
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
        playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);
    }

    private void Update()
    {
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ammo")
        {
            if (currentAmmo == maxAmmo)
            {
                Debug.Log("Player Ammo is full");
                AmmoFullSFX.Play();
            }
            else
            {
                Debug.Log("Ammo has been acquired!");
                currentAmmo += 10;
                AmmoAcquiredSFX.Play();
                playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);
                Destroy(collision.gameObject);
                
            }
        }

        if (collision.tag == "Ammo_Upgrade")
        {
            Debug.Log("Ammo Upgrade has collided");
            AmmoAcquiredSFX.Play();

            maxAmmo += 10;
            currentAmmo += 10;
            playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);

            Destroy(collision.gameObject);
        }

        if (collision.tag == "Damage_Upgrade")
        {
            Debug.Log("Damage Upgrade has collided");
            AmmoAcquiredSFX.Play();

            boltDamage += 2;

            playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(BoltDamage collision)
    {
    }

    public void UpdateAmmo()
    {
        playerAmmo.SetPlayerAmmo(currentAmmo, maxAmmo);
    }
}
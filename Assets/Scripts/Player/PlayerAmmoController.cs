using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoController : MonoBehaviour
{
    public PlayerAmmo playerAmmo;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            if (playerAmmo.startingAmmo == playerAmmo.maxAmmo)
            {
                Debug.Log("Player Ammo is full");
            }
            else
            {
                Debug.Log("Player has been healed");
                Destroy(collision.gameObject);
                playerAmmo.startingAmmo += 2;
            }
        }
    }
}
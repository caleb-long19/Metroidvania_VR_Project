using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{

    public GameObject SuperStrength;
    public GameObject GrappleHook;

    public AudioSource PickupAbility;
    public PlayerHealthController playerHealthController;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == SuperStrength)
        {
            //Increase Player Health & Damage
            playerHealthController.maxPlayerHealth += 4;
            playerHealthController.curPlayerHealth = playerHealthController.maxPlayerHealth;
            Debug.Log("Player has collided with Arm of Kratos");
            PickupAbility.Play();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject == GrappleHook)
        {
            Debug.Log("Player has collided with Grapple Hook");
            PickupAbility.Play();
            collision.gameObject.SetActive(false);
        }
    }
  }

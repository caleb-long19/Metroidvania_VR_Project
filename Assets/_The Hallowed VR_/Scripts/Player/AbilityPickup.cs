using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    // Game objects
    public GameObject SuperStrength;
    public GameObject GrappleHook;

    //Audio
    public AudioSource PickupAbility;

    //External Scripts
    public PlayerHealthController playerHealthController;

    private void OnTriggerEnter(Collider collision)
    {
        //If player collides with the super strength game object
        if (collision.gameObject == SuperStrength)
        {
            //Increase Player Health & Damage
            playerHealthController.maxPlayerHealth += 4;
            playerHealthController.curPlayerHealth = playerHealthController.maxPlayerHealth;

            //Play item pickup sfx and set the strength object to false in the hierarchy
            PickupAbility.Play();
            collision.gameObject.SetActive(false);

            Debug.Log("Player has collided with Arm of Kratos");
        }

        if (collision.gameObject == GrappleHook)
        {
            //If player pickups up the grapple hook ability, play item pickup sfx and disable the game object
            PickupAbility.Play();
            collision.gameObject.SetActive(false);

            Debug.Log("Player has collided with Grapple Hook");
        }
    }
  }

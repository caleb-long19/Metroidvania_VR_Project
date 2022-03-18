using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Crossbow : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip crossbowSound;
    public AudioClip crossbowEmptySound;
    public AudioClip crossbowReload;
    public GameObject crossbowBolt;
    public Transform boltLocation;

    public float crossbowFirerate = 0.1f;
    public float nextBolt = 0.0f;

    public float crossbowPower;
    private bool nowFiring = false;

    public SteamVR_Action_Boolean fireCrossbow;
    private Interactable interactable;

    public PlayerAmmoController playerAmmoCtrl;
    public int crntAmmo;

    // Start is called before the first frame update
    void Start()
    {
        if (boltLocation == null)
        {
            boltLocation = transform;
        }

        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        crntAmmo = playerAmmoCtrl.currentAmmo;

        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireCrossbow[source].stateDown)
            {
                nowFiring = true;
                Debug.Log("Trigger button is pressed");
            }
            if (fireCrossbow[source].stateUp)
            {
                nowFiring = false;
            }

            shootCrossbow();
        }
    }

    private void shootCrossbow()
    {
        SteamVR_Input_Sources source = interactable.attachedToHand.handType;

        if (nowFiring && Time.time > nextBolt && crntAmmo > 0)
        {
            nextBolt = Time.time + crossbowFirerate;
            Instantiate(crossbowBolt, boltLocation.position, boltLocation.rotation * Quaternion.Euler(0f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(boltLocation.forward * crossbowPower);
            crntAmmo -= 1;
            playerAmmoCtrl.currentAmmo = crntAmmo;
            playerAmmoCtrl.UpdateAmmo();
            audioSource.PlayOneShot(crossbowSound);
            audioSource.PlayOneShot(crossbowReload);
            Debug.Log("Bow has been fired!");
        }

        if (fireCrossbow[source].stateDown && crntAmmo <= 0)
        {
            Debug.Log("No more Ammo For Crossbow");
            audioSource.PlayOneShot(crossbowEmptySound);
        }
        
    }
}

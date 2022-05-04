using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class Crossbow : MonoBehaviour
{
    //Audio source and clips
    public AudioSource audioSource;
    public AudioClip crossbowSound;
    public AudioClip crossbowReload;
    public AudioClip crossbowEmptySound;

    public GameObject crossbowBolt;
    public Transform boltLocation;

    //Crossbow Values
    public float crossbowFirerate = 0.1f;
    public float nextBolt = 0.0f;
    public float crossbowPower;
    private bool nowFiring = false;

    //Store input from controller
    public SteamVR_Action_Boolean fireCrossbow;

    //Get components from crossbow game object
    private Interactable interactable;
    private LockToPoint lockToPoint;


    public PlayerAmmoController playerAmmoCtrl;
    public int crntAmmo;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve components on game object
        interactable = GetComponent<Interactable>();
        lockToPoint = GetComponent<LockToPoint>();
        lockToPoint.enabled = false;

        if (boltLocation == null)
        {
            boltLocation = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //store the current ammo count from the PlayerAmmoController into crntAmmo int
        crntAmmo = playerAmmoCtrl.currentAmmo;

        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            //If trigger is pressed, set bool to true
            if (fireCrossbow[source].stateDown)
            {
                nowFiring = true;
                Debug.Log("Trigger button is pressed");
            }
            //If trigger is unpressed, set bool to false
            if (fireCrossbow[source].stateUp)
            {
                nowFiring = false;
            }

            //Call method
            shootCrossbow();

            //Enable the locktopoint component, enabling the weapon holster
            lockToPoint.enabled = true;
        }
    }

    private void shootCrossbow()
    {
        SteamVR_Input_Sources source = interactable.attachedToHand.handType;

        if (nowFiring && Time.time > nextBolt && crntAmmo > 0)
        {
            //Prevent the crossbow from being spammed, wait for certain period of time before firing
            nextBolt = Time.time + crossbowFirerate;

            //Create bolt prefab based on the position of the boltLocation game object, use queaternion to roate prefab to accurate position, use add force to propel the crossbow bolt forward on the z axis
            Instantiate(crossbowBolt, boltLocation.position, boltLocation.rotation *
                Quaternion.Euler(0f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(boltLocation.forward * crossbowPower);
            
            //Remove one bolt from the ammo count, update the ammo ui on the crossbow of new ammo count
            crntAmmo -= 1;
            playerAmmoCtrl.currentAmmo = crntAmmo;
            playerAmmoCtrl.UpdateAmmo();

            //Play the crossbow firing sound effect and then play the reload sound effect
            audioSource.PlayOneShot(crossbowSound);
            audioSource.PlayOneShot(crossbowReload);

            Debug.Log("Bow has been fired!");
        }

        if (fireCrossbow[source].stateDown && crntAmmo <= 0)
        {
            //If the player fires the crossbow when ammo is empty, play the empty crossbow sound effect
            audioSource.PlayOneShot(crossbowEmptySound);

            Debug.Log("No more Ammo For Crossbow");
        }

    }
}


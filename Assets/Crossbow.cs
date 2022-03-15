using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Crossbow : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip crossbowSound;
    public GameObject crossbowBolt;
    public Transform boltLocation;

    public float crossbowFirerate = 0.1f;
    public float nextBolt = 0.0f;

    public float crossbowPower;
    private bool nowFiring = false;
    private bool checkTrigger = false;

    private InputDevice device;

    // Start is called before the first frame update
    void Start()
    {
        if(boltLocation == null)
        {
            boltLocation = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTrigger();
        shootCrossbow();
    }

    private void CheckTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nowFiring = true;
            Debug.Log("Trigger button is pressed");
        }
        if(Input.GetMouseButtonUp(0))
        {
            nowFiring = false;
        }
    }

    private void shootCrossbow()
    {
        if (nowFiring && Time.time > nextBolt)
        {
            nextBolt = Time.time + crossbowFirerate;
            Instantiate(crossbowBolt, boltLocation.position, boltLocation.rotation * Quaternion.Euler(0f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(boltLocation.forward * crossbowPower);
            audioSource.PlayOneShot(crossbowSound);
        }
    }
}

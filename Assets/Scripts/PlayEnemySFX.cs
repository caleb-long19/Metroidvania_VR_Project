using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemySFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioData;
    public AudioClip IdleSFX;
    public AudioClip MovingSFX;
    public AudioClip AttackingSFX;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void PlayIdleSFX()
    {
        audioData.PlayOneShot(IdleSFX);
    }

    void PlayMovingSFX()
    {
        audioData.PlayOneShot(MovingSFX);
    }

    void PlayAttackingSFX()
    {
        audioData.PlayOneShot(AttackingSFX);
    }
}

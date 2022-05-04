using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxPlayerHealth(int health)
    {
        //Get the slider object and set the max value
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetPlayerHealth(int health)
    {
        //Method to update the current slider value
        healthSlider.value = health;
    }
}

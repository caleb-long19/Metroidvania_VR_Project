using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    public void SetPlayerAmmo(int startingAmmo, int maxAmmo)
    {
        //Set the Player ammo canvas to display the current and max ammo ints by conveerting them to strings
        ammoText.text = startingAmmo.ToString() + "/" + maxAmmo;
    }
}

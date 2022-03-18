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
        ammoText.text = startingAmmo.ToString() + "/" + maxAmmo;
    }
}

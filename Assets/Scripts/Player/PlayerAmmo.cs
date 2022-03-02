using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int startingAmmo = 10;
    public int maxAmmo = 50;

    // Start is called before the first frame update
    void Start()
    {
        ammoText.text = startingAmmo.ToString();
    }
    void Update()
    {
        if (startingAmmo > maxAmmo)
        {
            startingAmmo = maxAmmo;
        }
    }
}

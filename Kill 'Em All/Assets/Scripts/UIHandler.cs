﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + PlayerController.currentAmmo.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text ammoText;
    public Text healthText;
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
        Blood();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + PlayerController.currentAmmo.ToString();
        healthText.text = "Health: " + PlayerController.healthCounter.ToString();
    }
    public void Blood()
    {
        if(PlayerController.healthCounter <= 0)
        {
            blood.SetActive(true);
        }
        else
        {
            blood.SetActive(false);
        }
    }
}

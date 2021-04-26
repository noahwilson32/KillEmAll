using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public Text ammoText;
    public Text healthText;
    public GameObject blood;
    public Animator bloodAnim;

    public GameObject deathScreen;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
        Blood();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
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
            bloodAnim.SetTrigger("isDrip");
            deathScreen.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            blood.SetActive(false);
            deathScreen.SetActive(false);
        }
    }

    public void Respawn()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerController.healthCounter = 100;
        PlayerController.currentAmmo = 6;
    }
    public void Pause()
    {

        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        Cursor.visible = true;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        Cursor.visible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    float originalZ;

    public float floatStrength;
    public Animator anim;
    private int hcInstance = 0;

    public GameObject fireBall;
    public Rigidbody2D fireRG;
    public float moveSpeedFire = 5f;
    public GameObject thePlayer;
    public float fireDistance = 10f;
    public static int numFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.originalZ = this.transform.position.z;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, originalZ + (Mathf.Sin(Time.time) * floatStrength));
        Flash(hcInstance);
        Chase();
    }
    public void Flash(int hc)
    {
        if(PlayerController.hitCounter > hc)
        {
            anim.SetTrigger("isFlash");
            hcInstance++;
        }

        if(PlayerController.hitCounter == 3)
        {
            Destroy(gameObject);
        }
    }

    public void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, thePlayer.transform.position);
        Vector3 spawnPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        if(distanceToPlayer <= fireDistance)
        {
            if(numFire <= 0)
            {
                Instantiate(fireBall, spawnPoint, Quaternion.identity);
                numFire++;
            }
        }
        fireRG.velocity = transform.forward * moveSpeedFire;
    }

}

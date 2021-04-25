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
    public GameObject thePlayer;
    public float fireDistance = 10f;
    public static int numFire = 0;


    float timer;
    public float waitTime = 2f;
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
        timer += Time.deltaTime;
        float distanceToPlayer = Vector2.Distance(transform.position, thePlayer.transform.position);
        if(distanceToPlayer <= fireDistance)
        {
            if(timer > waitTime)
            {
                if(PlayerController.healthCounter > 0)
                {
                    Instantiate(fireBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    timer = 0;
                }
            }
        }
    }

}

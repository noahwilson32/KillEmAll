using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    float originalZ;

    public float floatStrength;
    public Animator anim;
    private int hcInstance = 0;
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

}

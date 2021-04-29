using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Rigidbody2D rg;
    public float moveSpeed;

    private Vector3 direction;
    public Animator anim;
    public GameObject explosion;

    public static int timesHit = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction *= moveSpeed;
        float distance = Vector2.Distance(transform.position, PlayerController.instance.transform.position);
        if(distance > 1f && distance <= 10f)
        {
            rg.velocity = direction * moveSpeed;
            anim.SetBool("isWalking", true);
        }
        if(distance <= 1f)
        {
            rg.velocity = new Vector2(0,0);
            anim.SetBool("isWalking", false);
            Destroy(gameObject);
            GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionInstance, .5f);
            PlayerController.healthCounter -= 25;
        }
        if(distance > 10f)
        {
            rg.velocity = new Vector2(0, 0);
            anim.SetBool("isWalking", false);
        }
        if(timesHit >= 1)
        {
            Destroy(gameObject);
            GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionInstance, .5f);
        }
    }
}

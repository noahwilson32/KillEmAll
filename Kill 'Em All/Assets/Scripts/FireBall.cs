using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rg;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        rg.velocity = direction * moveSpeed;
    }
}

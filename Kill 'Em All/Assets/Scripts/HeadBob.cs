using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobSpeed = 14f;
    public float bobAmount = .05f;

    float defaultZ = 0;
    float timer = 0;

    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        defaultZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .1f || Mathf.Abs(Input.GetAxis("Vertical")) > .1f)
        {
            timer += Time.deltaTime * bobSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, defaultZ + Mathf.Sin(timer) * bobAmount);
        }
        else
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, defaultZ, Time.deltaTime * bobSpeed));
        }
    }
}

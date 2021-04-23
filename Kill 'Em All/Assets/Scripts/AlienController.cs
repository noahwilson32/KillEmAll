using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    float originalZ;

    public float floatStrength;
    // Start is called before the first frame update
    void Start()
    {
        this.originalZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, originalZ + (Mathf.Sin(Time.time) * floatStrength));
    }

}

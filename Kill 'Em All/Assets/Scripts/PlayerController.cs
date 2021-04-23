using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rg;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject hitMarker;

    public Animator gunAnim;

    public static int currentAmmo = 6;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Mouse();
        Shoot();
    }

    public void Move()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        rg.velocity = (moveHorizontal + moveVertical) * moveSpeed;
    }

    public void Mouse()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - mouseInput.x);
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
    }

    public void Shoot()
    {
        if(currentAmmo >= 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                currentAmmo -= 1;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(hitMarker, hit.point, transform.rotation);
                    Debug.Log("Hit!");
                    gunAnim.SetTrigger("isFire");
                }
            }
        }

        if(currentAmmo <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gunAnim.SetTrigger("isOut");
            }
        }
    }
}

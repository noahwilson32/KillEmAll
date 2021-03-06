using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public static int AlienHitCounter = 0;
    public static int healthCounter = 100;

    public GameObject screenFlash;
    public float waitTime = .1f;

    private int healthInstance = 100;

    public GameObject explosion;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        screenFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Mouse();
        Shoot();
        if(healthCounter <= 0)
        {
            healthCounter = 0;
        }
        TakeDamageFlash(healthInstance);
        
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


        if(Time.timeScale != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - mouseInput.x);
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
        }
    }

    public void Shoot()
    {
        if(currentAmmo >= 1)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                currentAmmo -= 1;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(hitMarker, hit.point, transform.rotation);
                    Debug.Log("Hit!");
                    gunAnim.SetTrigger("isFire");
                    if(hit.collider.gameObject.tag == "Alien")
                    {
                        AlienHitCounter++;
                    }
                    if(hit.collider.gameObject.tag == "Boom")
                    {
                        GameObject explosionInstance = Instantiate(explosion,hit.collider.gameObject.transform.position,Quaternion.identity);
                        Destroy(hit.collider.transform.parent.gameObject);
                        Destroy(explosionInstance, .5f);
                    }
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
    IEnumerator FlashScreen()
    {
        screenFlash.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        screenFlash.SetActive(false);
    }
    public void TakeDamageFlash(int hc)
    {
        if(hc > healthCounter)
        {
            StartCoroutine(FlashScreen());
            healthInstance -= 25;
        }
    }

}

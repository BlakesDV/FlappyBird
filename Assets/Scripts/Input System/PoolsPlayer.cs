using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class PoolsPlayer : MonoBehaviour
{

    private PoolScript bulletPool;
    private Player_Input_Actions playerInputs;

    public static Player1 instance;
    private bool canShoot;
    [SerializeField]
    private float timeToShoot;

    private float shootTimer;
    [Header("Player")]
    [SerializeField]
    private float speed = 3f;

    public Rigidbody2D rbPlayer;
    public Camera cam;

    private Vector2 moveInput;
    private Vector2 mousePos;

    [Header("Bullets")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField]
    private float speedBullet = 5f;
    [SerializeField]
    private float rFirePoint = 5f;

    // Start is called before the first frame update
    //Awake sucede primero, Awake sucede en el primer frame y Tart en el segundo, es para asegurora que se hagan bien las referencias.
    private void Awake()
    {
        playerInputs = new Player_Input_Actions();
        //bulletPool = GameObject
    }

    void Start()
    {
        //canShoot = false;

        playerInputs.Enable();
        rbPlayer = GetComponent<Rigidbody2D>();

        playerInputs.Standard.Shoot.performed += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Input.GetKeyDown("e") || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        */

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        FireRate();
        Move();
    }


    void FixedUpdate()
    {
        Move();
        //rbPlayer.MovePosition(rbPlayer.position + moveInput * speed * Time.fixedDeltaTime);


        /*Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle; */
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        //if (context.action.activeControl != null && canShoot)
        //{
        //    string inputKey = context.control.name;
        //    Debug.Log(inputKey);

        //    switch (inputKey)
        //    {
        //        case "downArrow":
        //            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0, -90));
        //            break;

        //        case "upArros":
        //            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 90));
        //            break;

        //        case "leftArrow":
        //            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 180));
        //            break;

        //        case "rightArrow":
        //            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //            break;

        //    }
        //    canShoot = false;
        //}

        Debug.Log("Dispara");
    }
    /*private void Shoot1()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
    } */

    private void FireRate()
    {
        if (!canShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                canShoot = true;
                shootTimer = timeToShoot;
            }
        }

    }
    private void Move()
    {
        //Vector3 direction = new Vector3(playerInputs.Standard.Move.ReadValue<Vector2>().x, playerInputs.Standard.Move.ReadValue<Vector2>().y,0).normalized;
        Vector2 direction = new Vector2(0, playerInputs.Standard.Move.ReadValue<float>()).normalized;

        rbPlayer.AddForce(direction * speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(firePoint.position, rFirePoint);
    }


    // Movimiento (Arriba, abajo, izquierda, derecha)
    // Disparo seguimiento de mouse con throwback
    // Seguimiento de enemigo
    // Más de una vida
    // Spawn Random




}
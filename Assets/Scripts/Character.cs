using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public static Character Instance;
    private PlayerInput playerInputActions;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeToShoot;
    [SerializeField] private int maxLife;
    private Rigidbody2D rb;
    private bool canShoot;
    private float shootTimer;
    private int life;


    //float vel = 5f;
    //public int dañoDisparo = 1;
    //public GameObject balaPrefab;
    //public Transform direccion;
    //public float velBala = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInputActions = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        shootTimer = timeToShoot;
        life = maxLife;

        playerInputActions.Enable();
        playerInputActions.PlayerMov.Shoot.performed += Shoot;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Point();
        fireRate();
    }

    private void fireRate()
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

    private void Point()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
    }

    private void Move()
    {
        Vector3 direction = new Vector3(playerInputActions.PlayerMov.MovimientoBasico.ReadValue<Vector2>().x, playerInputActions.PlayerMov.MovimientoBasico.ReadValue<Vector2>().y, 0).normalized;
        rb.AddForce(direction * speed);
        
        //float movH = Input.GetAxis("Horizontal");
        //float movV = Input.GetAxis("Vertical");
        //Vector2 mov = new Vector2(movH, movV);
        //transform.Translate(mov * vel * Time.deltaTime);
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.action.activeControl != null && canShoot)
        {
            string inputKey = playerInputActions.PlayerMov.Shoot.activeControl.name;
            Debug.Log(inputKey);
            switch (inputKey)
            {
                case "downArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
                    break;
                case "upArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;
                case "leftArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                    break;
                case "rightArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    break;
            }
            canShoot = false;

            //Algebra? punto A - B 
            //Instantiate(bala, direccion.position, Quaternion.identity);
            //Rigidbody2D balaRB = bala.GetComponent<Rigidbody2D>();
            //balaRB.velocity = new Vector2(0, velBala);

            //GameObject bala = Instantiate(balaPrefab, direccion.position, direccion.rotation);
            //Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            //rb.AddForce(direccion.up * velBala, ForceMode2D.Impulse);
        }
    }

    public void Hit(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}

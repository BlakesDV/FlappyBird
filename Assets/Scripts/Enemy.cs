using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Character Instance;
    private PlayerInput playerInputActions;

    [SerializeField] private int maxLifes;
    [SerializeField] private int damage;
    [SerializeField] private float attackTimeFrequency;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private int life;
    private bool canAttack;
    private float attackTimer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        life = maxLifes;
        canAttack = false;
        attackTimer = attackTimeFrequency;
    }
    void Update()
    {
        //Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Character.Instance != null)
        {
            Vector3 direction = (Character.Instance.transform.position - transform.position).normalized;
            rb.AddForce(direction * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Hit(int damage, Vector2 direction, float pushForce)
    {
        life -= damage;

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        //if()
        //{

        //}
    }
    private void Push()
    {
        //rb.AddForce(-direction * pushForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Character.Instance) { }
    }
}

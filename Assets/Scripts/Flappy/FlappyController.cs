using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FlappyController : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private FlappyActions flappyActions;
    private Rigidbody2D rb;

    private void Awake()
    {
        flappyActions = new FlappyActions();
        flappyActions.Enable();
    }

    void Start()
    {
        flappyActions.Standard.Jump.performed += Jump;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

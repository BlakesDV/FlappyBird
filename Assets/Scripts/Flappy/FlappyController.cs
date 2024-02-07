using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FlappyController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private FlappyInputs flappy;
    
    // Start is called before the first frame update
    void Start()
    {
        FlappyInputs.Basic.Jump.performed += Jump;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

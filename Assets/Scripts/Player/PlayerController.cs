using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 2f;
    public float maxSpeed = 5f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public bool grounded;
    public float jumpForce = 6.5f;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        //Get components
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            isJumping = true;
        }
    }


    private void FixedUpdate() {
        //Save horizontal axis
        float horizontal = Input.GetAxis("Horizontal");

        //Add force
        rigidbody2D.AddForce(Vector2.right * speed * horizontal);

        float limitedSpeed = Mathf.Clamp(rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2D.velocity = new Vector2(limitedSpeed, rigidbody2D.velocity.y);

        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);    
        } 
        else if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (isJumping)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }

    }

}

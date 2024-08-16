using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private CharacterAttack characterAttack;

    [SerializeField] private float groundCheckLength;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isFacingRight = true;
    private Vector2 velocity;
    [SerializeField] private bool isGrounded = false;
    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        PlayerMovement();
        PlayerJump();
        PlayerAttack();
    }

    private void PlayerMovement()
    {
        float xHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 velocity = new Vector2(xHorizontal * speed, rb.velocity.y);
        rb.velocity = velocity;
        
        characterAnimation.SetFloat("velocity", Mathf.Abs(velocity.x));
        FlipHander(velocity);
    }    

    private void FlipHander(Vector2 velocity)
    {
        Vector3 localScale = transform.localScale;
        if (isFacingRight)
        {
            if (velocity.x < 0)
            {
                isFacingRight = false;
                localScale.x = -1;
            }

        }
        else
        {
            if (velocity.x > 0)
            {
                isFacingRight=true;
                localScale.x = 1;
            }
        }
        transform.localScale = localScale;
    }    

    private void PlayerJump()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            rb.velocity = velocity;
            characterAnimation.SetTrigger("jump");
        }    
        
    }    

    private void GroundCheck()
    {
        Collider2D rch = Physics2D.OverlapCircle(groundCheck.position, groundCheckLength, groundLayer);
        if (rch == null)
        {
            isGrounded = false;
        }    
        else
        {
            isGrounded = true;
            characterAnimation.SetBool("isGrounded",isGrounded);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckLength);
    }

    private void PlayerAttack()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Q) && velocity.x == 0) 
            {
                characterAttack.Attack();
            }
        }
    }    
}

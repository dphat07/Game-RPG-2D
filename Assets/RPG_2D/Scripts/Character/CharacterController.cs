using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CharacterAnimation characterAnimation;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float xHorizontal = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(xHorizontal * speed, rb.velocity.y);
        rb.velocity = velocity;
        
        characterAnimation.SetFloat("velocity", Mathf.Abs(velocity.x));
    }    
}

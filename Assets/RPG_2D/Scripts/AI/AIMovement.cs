using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected bool isFacingRight;
    [SerializeField] protected Rigidbody2D rb;

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void FlipHander(Vector2 velocity)
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
                isFacingRight = true;
                localScale.x = 1;
            }
        }
        transform.localScale = localScale;
    }
}

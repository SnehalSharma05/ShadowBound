using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool wasGroundedLastFrame = true;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");

        // Update the animator's Speed parameter
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        Vector2 position = transform.position; // Player's position
        Vector2 direction = Vector2.up; // Direction to check for ground
        float distanceToGround = 7f; // How far below the player to check for ground
        float radius = 2.5f; // Radius of the overlap circle
        LayerMask groundLayer = LayerMask.GetMask("Ground"); // Layer mask to only check for only ground layer

        // Check if there's ground within the circle area below the player
        Collider2D groundCollider = Physics2D.OverlapCircle(position + direction * distanceToGround, radius, groundLayer);
        // Update grounded status based on whether a ground was found
        isGrounded = groundCollider != null;

        // Update the animator's Grounded parameter
        animator.SetBool("Grounded", isGrounded);

        // Invoke jumping after jumping animation is over and player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            Invoke("Jump", 0.185f);
        }

        // Check if the player is grounded
        if (isGrounded && !wasGroundedLastFrame)
        {
            animator.SetTrigger("Land");
        }
        wasGroundedLastFrame = isGrounded;

        // Flip the character based on direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    // Draw a circle at the position where the ground check happens for reference
    void OnDrawGizmos()
    {
        Vector2 position = transform.position; // Player's position
        Vector2 direction = Vector2.up; // Direction to check for ground
        float distanceToGround = 7f; // How far below the player to check for ground
        float radius = 2.5f; // Radius of the overlap circle

        // Calculate the final position of the circle
        Vector2 finalPosition = position + direction * distanceToGround;

        // Draw a red circle at the position where the ground check happens
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(finalPosition, radius);
    }

    // Jumping function
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }

    // Apply horizontal movement in FixedUpdate to avoid jittery movement
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Grounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Grounded", false);
        }
    }*/
}



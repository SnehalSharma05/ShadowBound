using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool wasGroundedLastFrame=true;
    private bool facingRight = true;
    [SerializeField]
    private GameObject landFx, walkFx;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Play walk sound effect
        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.1f && !walkFx.GetComponent<AudioSource>().isPlaying)
        {
            walkFx.GetComponent<AudioSource>().Play();
        }
        else if (isGrounded && Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            walkFx.GetComponent<AudioSource>().Stop();
        }
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");

        // animator's Speed parameter
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distanceToGround = 7f; 
        float radius = 2.5f; // Radius of the overlap circle
        LayerMask groundLayer = LayerMask.GetMask("Ground"); // Layer mask for ground layer

        // check if there's ground below
        Collider2D groundCollider = Physics2D.OverlapCircle(position + direction * distanceToGround, radius, groundLayer);
        isGrounded = groundCollider != null;

 
        animator.SetBool("Grounded", isGrounded);

        // check if the player is grounded
        if (isGrounded && !wasGroundedLastFrame)
        {
            animator.SetTrigger("Land");
            landFx.GetComponent<AudioSource>().Play();
        }
        wasGroundedLastFrame = isGrounded;

        // jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            Invoke("Jump", 0.185f);
        }

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
    void OnDrawGizmos()
    {
        Vector2 position = transform.position; // Player's position
        Vector2 direction = Vector2.down; // Direction to check for ground
        float distanceToGround = 7f; // How far below the player to check for ground
        float radius = 2.5f; // Radius of the overlap circle

        // Calculate the final position of the circle
        Vector2 finalPosition = position + direction * distanceToGround;

        // Draw a red circle at the position where the ground check happens
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(finalPosition, radius);
    }

    // Jump function
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void FixedUpdate()
    {
        // Apply horizontal movement in FixedUpdate to avoid jittery movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}



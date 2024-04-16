using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    private Animator animator;


    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Flip the character sprite if moving right
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
        if (Input.GetKey("space") && isGrounded && canJump)//Add active
        {
            animator.SetBool("IsCharging", true);
            jumpValue += 0.1f;
            animator.SetBool("IsFalling", false);
        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)//Add active
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpValue >= 20f && isGrounded)//Add inactive
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
            //animator.SetBool("IsCharging", false);
            animator.SetBool("IsFalling", false);
        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                animator.SetBool("IsFalling", false);
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
            }
            canJump = true;
            if (!isGrounded)
            {
                animator.SetBool("IsCharging", false);

            }

        }
        // Determine jump and fall animations based on vertical velocity
        if (rb.velocity.y > 0.1f)
        {
            // Player is jumping
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if (rb.velocity.y < -0.1f)
        {
            // Player is falling
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else
        {
            // Player is neither jumping nor falling
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);

        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f), new Vector2(0.9f, 0.2f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Next")
        {
            SceneManager.LoadScene("Nexttt");
        }
    }

}

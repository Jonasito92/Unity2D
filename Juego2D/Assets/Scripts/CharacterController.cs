using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBody;
    private float inputMovement;
    public bool isLookingRight = true, isOnFloor = false;
    public float jumpForce;
    private BoxCollider2D boxCollider;
    public LayerMask surfaceLayer;
    //Animator
    public bool isRunning;
    public bool isJumping;
    Animator animator;
    private bool canDoubleJump = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessingMovement();
        ProcessingJump();
        isOnFloor = CheckingFloor();
    }

    bool CheckingFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
                                        boxCollider.bounds.center,
                                        new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),
                                        0f,
                                        Vector2.down,
                                        0.2f,
                                        surfaceLayer
                                        );
        return raycastHit.collider != null;
    }

    void ProcessingMovement()
    {
        inputMovement = Input.GetAxis("Horizontal");
        isRunning = inputMovement != 0 ? true : false;
        animator.SetBool("isRunning", isRunning);

        rigidBody.velocity = new Vector2(inputMovement * speed, rigidBody.velocity.y);
        CharacterOrientation(inputMovement);
    }

    void CharacterOrientation(float inputMovement)
    {
        if ((isLookingRight && inputMovement < 0) || (!isLookingRight && inputMovement > 0))
        {
            isLookingRight = !isLookingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void ProcessingJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnFloor)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                    rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    canDoubleJump = false;
                }
            }
        }
        else
        {
            if (!isOnFloor)
            {
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
            }
            else
            {
                isJumping = false;
                animator.SetBool("isJumping", isJumping);
                canDoubleJump = true; // Reiniciar el doble salto al tocar el suelo
            }
        }
    }

}


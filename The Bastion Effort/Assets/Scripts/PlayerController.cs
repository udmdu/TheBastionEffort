using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private float input;

    public LayerMask groundLayer, structureLayer;
    private bool isGrounded;
    private float horizontalMove;
    public Transform feetPosition;
    public float groundCheckCircle;
    public float playerHealth;

    public float damage;
    public HealthBar healthBar;
    public float healAmount;
    public float healDelay;
    private bool canHeal = false;
    private float timeUntilHeal;
    private bool facingRight;

    // Update is called once per frame
    void Update()
    {

        //Player movement left and right
        horizontalMove = input = Input.GetAxisRaw("Horizontal");

          if(Mathf.Abs(horizontalMove) == 0 && playerHealth < healAmount)
        {
            timeUntilHeal = Time.time + healDelay;
            canHeal = true;
            if (Time.time > timeUntilHeal && playerHealth < healAmount)
            {
                playerHealth += healAmount;
                canHeal = false;
            }
        }

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer) || Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, structureLayer))
        {
            isGrounded = true;
        } else 
        {
            isGrounded = false;
        }

        //Player jump
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);


        //flips the player depending on the mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        if (difference.x >= 0 && !facingRight)
        { // mouse is on right side of player
            spriteRenderer.flipX = true;
            facingRight = true;
        }
        if (difference.x < 0 && facingRight)
        { // mouse is on left side
            spriteRenderer.flipX = false;
            facingRight = false;
        }

        healthBar.SetHealth(playerHealth);
    }

    
}

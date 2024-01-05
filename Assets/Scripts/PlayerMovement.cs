using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;

    private Rigidbody2D rb2D;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    private LayerMask groundMask;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(moveX * speed, rb2D.velocity.y);

        if (moveX > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveX < -0.01f)
             transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("running", moveX != 0);

        if (Input.GetKey("space"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundMask);
    }
}

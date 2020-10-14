using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb2d;

    public bool grounded;
    public LayerMask whatisGround;

    private Collider2D collider2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Only allow 1 jump
        grounded = Physics2D.IsTouchingLayers(collider2d, whatisGround);

        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        //PC CONTROLS
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            { 
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }
    }
}

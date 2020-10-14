using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncrease;
    private float speedIncreaseStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;


    public float jumpForce;

    private Rigidbody2D rb2d;

    public bool grounded;
    public LayerMask whatisGround;

    private Collider2D collider2d;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

        speedMilestoneCount = speedIncrease;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseStore = speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        //Only allow 1 jump
        grounded = Physics2D.IsTouchingLayers(collider2d, whatisGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncrease;

            speedIncrease = speedIncrease * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncrease = speedIncreaseStore;
        }
    }
}

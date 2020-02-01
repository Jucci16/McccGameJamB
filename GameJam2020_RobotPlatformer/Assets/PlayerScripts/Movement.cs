///==================================================================
///Author: Zackary Moore
///Date  : 09-12-2019
///Desc  : Script dealing with player movement, jumping and flipping
///        our player sprite
///==================================================================        
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    private float tempspeed;
    private Rigidbody2D playerRigidBody;
    private float inputHorz;
    public float maxMoveSpeed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float accel;
    private float lastVelocity;
    public float Deceleration;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    // true if the player is currently on the ground
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        ///get the rididbody component that is attached to our player
        playerRigidBody = GetComponent<Rigidbody2D>();
        tempspeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        jump();
        crouch();
    }

    private void crouch()
    {
        //if(Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    gameObject.GetComponent<BoxCollider2D>().transform.localScale
        //}
    }

    private void horizontalMovement()
    {
        ///Use built in horizontal movement detection to see which key is being pressed
        ///works with left arrow, right arrow, a, and d
        inputHorz = Input.GetAxisRaw("Horizontal");

        accelerate();
        deceleration();
        ///Apply a horizontal movement to the player based on the movement speed
        playerRigidBody.velocity = new Vector2(inputHorz * movementSpeed, playerRigidBody.velocity.y);

        ///If inputHorz is greater than 0, my player is moving to the right
        if(inputHorz > 0)
        {
            flipPlayerRight();
        }
        ///If inputHorz is less than 0, my player is moving to the left
        else if(inputHorz < 0)
        {
            flipPlayerLeft();
        }
    }
    /// <summary>
    /// Player Jump.
    /// </summary>
    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ///Apply a vertical velocity to our player based on jumpForce
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            ///Another way to apply a vertical velocity to our player based on jumpForce
            //playerRigidBody.velocity = Vector2.up * jumpForce;
        }
        if(playerRigidBody.velocity.y < 0)
        {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        else if(playerRigidBody.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void accelerate()
    {
        if (playerRigidBody.velocity.x != 0 && movementSpeed < maxMoveSpeed)
        {
            movementSpeed += accel;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movementSpeed = tempspeed;
        }
    }

    private void deceleration()
    {
        if (playerRigidBody.velocity.x != 0 && movementSpeed < maxMoveSpeed && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)))
        {
            movementSpeed -= Deceleration;
        }
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    movementSpeed = tempspeed;
        //}

    }

    /// NOTE: this function does not work correctly if the camera is a child of the player
    private void flipPlayerLeft()
    {
        ///This is used to rotate the player
        //transform.eulerAngles = new Vector2(0, 180);
    }

    /// NOTE: this function does not work correctly if the camera is a child of the player
    private void flipPlayerRight()
    {
        ///This is used to rotate the player
        //transform.eulerAngles = new Vector2(0, 0);
    }

    // Is the player touching the ground
    public bool isPlayerGrounded()
    {
        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boundaries"))
        {
            //Debug.Log("OB");
            SceneManager.LoadScene("SampleScene");
        }
        // set grounded to true if collided with the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // set grounded to false if left the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}

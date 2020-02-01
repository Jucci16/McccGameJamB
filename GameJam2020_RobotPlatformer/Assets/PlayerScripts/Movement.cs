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
    private Rigidbody2D playerRigidBody;
    private float inputHorz;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        ///get the rididbody component that is attached to our player
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        jump();
    }

    private void horizontalMovement()
    {
        ///Use built in horizontal movement detection to see which key is being pressed
        ///works with left arrow, right arrow, a, and d
        inputHorz = Input.GetAxisRaw("Horizontal");

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

    private void jump()
    {
        ///We can use this to check if a key was pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ///Apply a vertical velocity to our player based on jumpForce
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            ///Another way to apply a vertical velocity to our player based on jumpForce
            //playerRigidBody.velocity = Vector2.up * jumpForce;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boundaries"))
        {
            //Debug.Log("OB");
            SceneManager.LoadScene("SampleScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : BaseModule
{
    // is the player allowed to use a double jump (set to false after they perform the action)
    bool canJump = true;

    public override void apply(GameObject player)
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            // if the player is not grounded, a double jump action can occur
            Movement playerCurrentMovement = player.GetComponent<Movement>();
            if (!playerCurrentMovement.isPlayerGrounded())
            {
                // jump action
                Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerCurrentMovement.jumpForce);
                // do not allow the user to jump again until they touch the ground
                canJump = false;
            }
        }
    }

    public override string onEnableText()
    {
        return "Double Jump Enabled (Spacebar)";
    }

    public override void onUpdate(GameObject player)
    {
        // if canJump is false, check if it can be reset
        if (!canJump)
        {
            Movement playerCurrentMovement = player.GetComponent<Movement>();
            if(playerCurrentMovement.isPlayerGrounded())
            {
                canJump = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : BaseModule
{
    private const float defaultHoverTime = 0.5f;
    // current time left to hover
    private float hoverTimeLeft = defaultHoverTime;
    // top height of a player's jump
    Vector3 topOfJumpPosition = Vector3.zero;

    public override string moduleName => "Hover";

    public override void apply(GameObject player)
    {
        // check if the space is being held down
        if (Input.GetKey(KeyCode.Space) && hoverTimeLeft > 0)
        {
            // check if the user is naturally falling
            if (topOfJumpPosition != Vector3.zero && topOfJumpPosition.y > player.transform.position.y)
            {
                // add vertical velocity to make player hover
                Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
                Movement playerMovement = player.GetComponent<Movement>();
                playerRigidBody.velocity = Vector2.up * (playerMovement.jumpForce / 15f);

                // since player is currently hovering, decrement the time left to hover
                hoverTimeLeft -= Time.deltaTime;
            } 
            // otherwise the player is still rising, so update the top height
            else
            {
                topOfJumpPosition = player.transform.position;
            }
        } else
        {
            // since player is releasing hover, then update topOfJumpPosition
            topOfJumpPosition = player.transform.position;
            if (hoverTimeLeft <= 0)
            {
                // reset jump position
                topOfJumpPosition = Vector3.zero;
            }
        }
    }

    public override string onEnableText()
    {
        return "Hover Enabled (Hold Spacerbar)";
    }

    public override void onUpdate(GameObject player)
    {
        // checks if the hoverTimeLeft can be reset
        if (hoverTimeLeft <= 0)
        {
            Movement playerCurrentMovement = player.GetComponent<Movement>();
            if (playerCurrentMovement.isPlayerGrounded())
            {
                hoverTimeLeft = defaultHoverTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BaseModule
{
    public override string spritePath => "Sprites/modules/GrappleHookx64";

    public override string name => "Dash";

    private bool canDash = true;

    private bool isActive = false;

    private float lastActivated;
    private float timeLeft = .4f;

    [SerializeField]
    private float dashSpeed = 25;

    public override void apply(GameObject player)
    {
        if (!canDash 
            || !Input.GetKeyDown(KeyCode.LeftShift) 
            || player.GetComponent<Movement>().isPlayerGrounded()
            || Time.realtimeSinceStartup - lastActivated <= 5)
        {
            return;
        }


        player.GetComponent<Movement>().movementSpeed = dashSpeed;

        isActive = true;
        canDash = false;
        lastActivated = Time.timeSinceLevelLoad;
    }

    public override string onEnableText()
    {
        return "Dash Enabled (Left Shift)";
    }

    public override void onUpdate(GameObject player)
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
        }
        if (isActive && timeLeft <=0)
        {
            isActive = false;
            var movement = player.GetComponent<Movement>();
            movement.movementSpeed = movement.maxMoveSpeed;
            resetTimeLeft();
        }

        // if canJump is false, check if it can be reset
        if (!canDash)
        {
            Movement playerCurrentMovement = player.GetComponent<Movement>();
            if (playerCurrentMovement.isPlayerGrounded())
            {
                canDash = true;
            }
        }
    }

    private void resetTimeLeft()
    {
        timeLeft = .4f;
    }
}

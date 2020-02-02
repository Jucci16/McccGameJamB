using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorTrigger : IDoorState
{
    /// <summary>
    /// True if the door is open
    /// </summary>
    private bool isOpen = false;
    public Vector3 playerTeleportPosition;

    string frontDoorOnSprite = "Sprites/door/door_front_on";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                collision.gameObject.transform.position = playerTeleportPosition;
            }
        }
    }

    /// <summary>
    /// Open the door
    /// </summary>
    public override void openDoor()
    {
        isOpen = true;
    }

    public override void updateSprite(bool on)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(frontDoorOnSprite);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    /// <summary>
    /// True if the door is open
    /// </summary>
    private bool isOpen = false;
    /// <summary>
    /// Initial position of the door
    /// </summary>
    private Vector3 initialPosition;
    /// <summary>
    /// Height to move the door
    /// </summary>
    private float heightToMove;

    private float doorSpeed = 2f;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
        heightToMove = gameObject.transform.localScale.y;
    }

    void Update()
    {
        // if door should be open/opening
        if(isOpen)
        {
            // if door is not fully open, continue opening
            if (gameObject.transform.position.y < (initialPosition.y + heightToMove))
            {
                gameObject.transform.Translate(new Vector3(0, Time.deltaTime * doorSpeed, 0));
            }
        }
    }

    /// <summary>
    /// Open the door
    /// </summary>
    public void openDoor()
    {
        isOpen = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchTrigger : MonoBehaviour
{
    /// <summary>
    /// Door object that this switch will open
    /// </summary>
    public GameObject door;
    /// <summary>
    /// Has this switch been turned on. It can only be turned on once
    /// </summary>
    bool isSwitchedOn = false;
    /// <summary>
    /// True if the player is currently colliding with the switch object
    /// </summary>
    bool isPlayerOverSwitch = false;

    private void Update()
    {
        if(isPlayerOverSwitch && !isSwitchedOn)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayerBatteryManager playerBatteryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBatteryManager>();
                if (playerBatteryManager.hasBattery())
                {
                    // remove a battery from the user's inventory
                    playerBatteryManager.useBattery();

                    // open the door
                    door.GetComponent<DoorState>().openDoor();

                    isSwitchedOn = true;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOverSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOverSwitch = false;
        }
    }
}

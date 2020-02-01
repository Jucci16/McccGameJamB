using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBatteryManager : MonoBehaviour
{
    /// <summary>
    /// Number of batteries the player has obtained
    /// </summary>
    private int batteryCount;

    void Start()
    {
        batteryCount = 0;
    }

    // Adds a battery to the user's inventory
    public void addBatteryToInventory()
    {
        batteryCount++;
    }

    // Removes a battery from the user's inventory
    public void useBattery()
    {
        batteryCount--;
    }

    /// <summary>
    /// True if the player has at least one battery
    /// </summary>
    public bool hasBattery()
    {
        return batteryCount > 0;
    }
}

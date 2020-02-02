using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // add a battery to the user's inventory
            PlayerBatteryManager playerBatteryManager = collision.gameObject.GetComponent<PlayerBatteryManager>();
            playerBatteryManager.addBatteryToInventory();

            // display the text overlay for the battery
            GameObject textOverlay = GameObject.FindGameObjectWithTag("UIOverlay");
            textOverlay.GetComponent<ModuleTextOverlay>().setText("Battery Obtained (F to use)");

            // now delete this game object from the screen
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class if for managing a collision between the player and a module
public class ModuleTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // retrieve the player's obtained module list and add the new module
            PlayerModuleManager playerModuleManager = collision.gameObject.GetComponent<PlayerModuleManager>();
            playerModuleManager.addModule(new DoubleJump()); // TODO hardcoded doublejump

            // now delete this game object from the screen
            Destroy(this.gameObject);
        }
    }
}

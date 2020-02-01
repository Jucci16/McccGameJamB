using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class if for managing a collision between the player and a module
public class ModuleTrigger : MonoBehaviour
{
    public GameObject textOverlay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // retrieve action type
            IModuleItemType moduleType = gameObject.GetComponent<IModuleItemType>();
            BaseModule moduleAction = moduleType.getModuleAction();

            // retrieve the player's obtained module list and add the new module
            PlayerModuleManager playerModuleManager = collision.gameObject.GetComponent<PlayerModuleManager>();
            playerModuleManager.addModule(moduleAction); 

            // display the text overlay for this module's function
            GameObject overlayObject = Instantiate(textOverlay);
            overlayObject.GetComponent<ModuleTextOverlay>().setText(moduleAction.onEnableText());

            // now delete this game object from the screen
            Destroy(this.gameObject);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

// This class is the manager for a player's modules
public class PlayerModuleManager : MonoBehaviour
{
    /// <summary>
    /// Called on creation
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Update Module first to ensure module has correct player state.
        UpdateModules();
        ApplyModules();
        setSelectedModule();
    }

    /// <summary>
    /// Add a module to the list of obtained modules
    /// </summary>
    /// <param name="module"></param>
    public void addModule(BaseModule module)
    {
        GetInventory().addModule(module);
    }

    /// <summary>
    /// Apply Module Effects
    /// </summary>
    protected void ApplyModules()
    {
        var selectedModule = GetInventory().getSelectedModule();
        if (selectedModule == null)
        {
            return;
        }

        selectedModule.apply(gameObject);
    }

    /// <summary>
    /// Update Module information. 
    /// Important for modules like jump or hover
    /// </summary>
    protected void UpdateModules()
    {
        var selectedModule = GetInventory().getSelectedModule();
        selectedModule?.onUpdate(gameObject);
    }

    /// <summary>
    /// Set the selected Module by index
    /// </summary>
    /// <param name="index">Index of module in obtained Modules</param>
    public void setSelectedModule()
    {
        var index = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 3;
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 4;
        } else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 5;
        } else
        {
            return;
        }

        GetInventory().selectModule(index);
    }

    /// <summary>
    /// Get the Module that is currently selected
    /// </summary>
    /// <returns>Currently selected Module</returns>
    public BaseModule getSelectedModule()
    {
        return GetInventory()?.getSelectedModule();
    }

    private Inventory GetInventory()
    {
        return GameObject.FindGameObjectWithTag("ItemBar").GetComponentInChildren<Inventory>();
    }

    /// <summary>
    /// Update the sprite for the player
    /// </summary>
    /// <param name="path">path of the sprite</param>
    private void updatePlayerSprite(string path)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is the manager for a player's modules
public class PlayerModuleManager : MonoBehaviour
{
    /// <summary>
    /// list of modules the player has obtained
    /// </summary>
    private List<BaseModule> obtainedModules;

    /// <summary>
    /// Currently selected Module
    /// </summary>
    private BaseModule _selectedModule;

    /// <summary>
    /// Called on creation
    /// </summary>
    void Start()
    {
        obtainedModules = new List<BaseModule>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Update Module first to ensure module has correct player state.
        UpdateModules();
        ApplyModules();

    }

    /// <summary>
    /// Add a module to the list of obtained modules
    /// </summary>
    /// <param name="module"></param>
    public void addModule(BaseModule module)
    {
        

         if (obtainedModules.Contains(module))
        {
            Debug.Log("Module is already collected");
            return;
        }

        obtainedModules.Add(module);

        // Add the newly grabbed Module as the selected Module
        setSelectedModule(obtainedModules.Count - 1);
        GetInventory().addInventoryItem(module);
    }

    /// <summary>
    /// Apply Module Effects
    /// </summary>
    protected void ApplyModules()
    {
        var selectedModule = getSelectedModule();
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
        // Null check
        if (obtainedModules == null || obtainedModules.Count <= 0)
        {
            return;
        }

        // Iterate through each module and update it with the 
        // Players current state.
        foreach (BaseModule module in obtainedModules)
        {
            module.onUpdate(gameObject);
        }
    }

    /// <summary>
    /// Set the selected Module by index
    /// </summary>
    /// <param name="index">Index of module in obtained Modules</param>
    public void setSelectedModule(int index)
    {
        if (obtainedModules == null || index >= obtainedModules.Count)
        {
            return;
        }

        _selectedModule = obtainedModules[index];
    }

    /// <summary>
    /// Get the Module that is currently selected
    /// </summary>
    /// <returns>Currently selected Module</returns>
    public BaseModule getSelectedModule()
    {
        return _selectedModule;
    }

    /// <summary>
    /// Get index by Module
    /// </summary>
    /// <param name="module">Module that you'd like the index of</param>
    /// <returns> -1 if not found. Index of the module if found</returns>
    public int getModuleIndex(BaseModule module)
    {
        // Iterate through each module and compare the module names
        for (var i = 0; i < obtainedModules.Count; i++)
        {
            if (module.name == obtainedModules[i].name)
            {
                return i;
            }
        }

        return -1;
    }


    private Inventory GetInventory()
    {
        return GameObject.FindGameObjectWithTag("ItemBar").GetComponentInChildren<Inventory>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is the manager for a player's modules
public class PlayerModuleManager : MonoBehaviour
{
    // list of modules the player has obtained
    private List<BaseModule> obtainedModules;

    void Start()
    {
        obtainedModules = new List<BaseModule>();
    }

    // Update is called once per frame
    void Update()
    {
        // first loop through each module and perform the update action if needed
        foreach(BaseModule module in obtainedModules)
        {
            module.onUpdate(gameObject);
        }
        // next execute the action of the selected module
        // TODO instead we will use the selected module here
        if (obtainedModules.Count > 0)
        {
            obtainedModules[0].apply(gameObject);
        }
    }

    // Add a module to the list of obtained modules
    public void addModule(BaseModule module)
    {
        obtainedModules.Add(module);
    }
}

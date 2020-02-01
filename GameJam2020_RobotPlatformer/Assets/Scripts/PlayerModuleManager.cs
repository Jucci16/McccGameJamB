using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

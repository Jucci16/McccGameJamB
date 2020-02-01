using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModuleManager : MonoBehaviour
{
    // list of modules the player has obtained
    List<BaseModule> obtainedModules;

    void Start()
    {
        obtainedModules = new List<BaseModule>();
        obtainedModules.Add(new DoubleJump());
    }

    // Update is called once per frame
    void Update()
    {
        obtainedModules[0].apply(gameObject);
    }
}

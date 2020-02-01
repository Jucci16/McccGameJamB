using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IModuleItemType : MonoBehaviour
{
    /// <returns>the type of module action</returns>
    public abstract BaseModule getModuleAction();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashModuleItemType : IModuleItemType
{
    public override BaseModule getModuleAction()
    {
        return new Dash();
    }
}

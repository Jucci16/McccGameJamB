using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverItemType : IModuleItemType
{
    public override BaseModule getModuleAction()
    {
        return new Hover();
    }
}

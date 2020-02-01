using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpItemType : IModuleItemType
{
    public override BaseModule getModuleAction()
    {
        return new DoubleJump();
    }
}

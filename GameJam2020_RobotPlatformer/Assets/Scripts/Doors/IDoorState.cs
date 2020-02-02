using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDoorState : MonoBehaviour
{
    public abstract void openDoor();

    public abstract void updateSprite(bool on);
}

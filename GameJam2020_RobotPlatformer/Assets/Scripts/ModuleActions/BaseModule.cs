using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModule
{
    protected bool _isActive;
    public abstract string spritePath { get; }

    public abstract string name { get; }

    public abstract void apply(GameObject player);

    public abstract void onUpdate(GameObject player);

    public abstract string onEnableText();

    public bool isActive()
    {
        return _isActive;
    }

    public void isActive(bool active) 
    {
        _isActive = active;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public BaseModule module { get; set; }

    public void changeColor(Color color) 
    {
        var button = gameObject.gameObject.GetComponentInChildren<Button>();
        button.image.color = color;
    }
}

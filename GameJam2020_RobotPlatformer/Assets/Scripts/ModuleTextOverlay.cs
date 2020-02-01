using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleTextOverlay : MonoBehaviour
{
    private const float defaultDisplayTime = 3f;
    private float timeLeft;

    void Start()
    {
        // set display time to the default
        timeLeft = defaultDisplayTime;
    }


    void Update()
    {
        // if the time is up, destroy this game object
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setText(string text)
    {
        Text textObject = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        textObject.text = text;
    }
}

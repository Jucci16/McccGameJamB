using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleTextOverlay : MonoBehaviour
{
    private const float defaultDisplayTime = 3f;
    private float timeLeft;
    private bool isDisplaying = false;

    void Start()
    {
        // set display time to the default
        timeLeft = defaultDisplayTime;
    }


    void Update()
    {
        if (isDisplaying)
        {
            // if the time is up, clear the text
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Text textObject = GetComponent<Text>();
                textObject.text = "";
                isDisplaying = false;
            }
        }
    }

    public void setText(string text)
    {
        Text textObject = GetComponent<Text>();
        textObject.text = text;

        // reset timer
        timeLeft = defaultDisplayTime;
        isDisplaying = true;
    }
}

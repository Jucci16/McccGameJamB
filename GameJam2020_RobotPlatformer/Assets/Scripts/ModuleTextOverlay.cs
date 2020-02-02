using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleTextOverlay : MonoBehaviour
{
    private const float defaultDisplayTime = 3f;
    private float timeLeft;
    private bool isDisplaying = false;

    private const string startingText1 = "Fix the robot by obtaining modules.";
    private const string startingText2 = "Select modules by pressing [1,2,3,4,5]";

    void Start()
    {
        // set starting text color
        Text textObject = GetComponent<Text>();
        textObject.color = Color.blue;
        // set starting text
        setText(startingText1);
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
                if (textObject.text.Equals(startingText1))
                {
                    setText(startingText2);
                }
                else
                {
                    // reset color
                    textObject.color = Color.white;
                    // reset text
                    textObject.text = "";
                    isDisplaying = false;
                }
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

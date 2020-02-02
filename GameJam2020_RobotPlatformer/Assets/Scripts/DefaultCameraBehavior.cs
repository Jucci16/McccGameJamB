using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCameraBehavior : MonoBehaviour
{
    void Start()
    {
        // set the main aspect ratio of the camera
        Camera.main.aspect = 16f / 9f;
    }
}

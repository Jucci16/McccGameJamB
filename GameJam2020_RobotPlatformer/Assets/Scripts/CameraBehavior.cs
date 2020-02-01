using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private GameObject player;

    // speed of the camera movement
    private float cameraShiftSpeed = 25f;
    // 1 if right, -1 if left
    private float cameraMoveDirection = 0;
    // amount the camera should move. if it should not move, value is 0
    private float cameraAmountToMove = 0;
    // amount the camera has currently moved in its current shift
    private float cameraAmountMoved = 0;

    void Start()
    {
        // set the main aspect ratio of the camera
        Camera.main.aspect = 16f / 9f;
        // get player object
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // check if camera should be moving
        if (cameraAmountToMove != 0)
        {
            // check if camera has reached its destination
            if (cameraAmountMoved < cameraAmountToMove)
            {
                float moveAmount = Time.deltaTime * cameraShiftSpeed;
                // make sure the camera doesn't move past the cameraAmountToMove
                if(cameraAmountMoved + moveAmount > cameraAmountToMove)
                {
                    moveAmount = cameraAmountToMove - cameraAmountMoved;
                }
                // move camera
                Camera.main.transform.Translate(new Vector3(moveAmount * cameraMoveDirection, 0, 0));
                // update amount moved
                cameraAmountMoved += moveAmount;
            } else
            {
                // camera position has been reached. reset values
                cameraAmountToMove = 0;
                cameraAmountMoved = 0;
                cameraMoveDirection = 0;
            }
        } else
        {
            // get the location of the player
            Vector3 playerPosition = player.transform.position;
            // check if the player is outside of the camera view
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(playerPosition);
            if (screenPoint.x <= 0) // player is left of the camera
            {
                cameraMoveDirection = -1;
                cameraAmountToMove = getCameraWidth();
            }
            else if (screenPoint.x >= 1) // players is right of the camera
            {
                cameraMoveDirection = 1;
                cameraAmountToMove = getCameraWidth();
            }
        }
    }

    /// <summary>
    /// Retrieve the camera width
    /// </summary>
    /// <returns>width of the camera</returns>
    private float getCameraWidth()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        return halfWidth * 2;
    }
}

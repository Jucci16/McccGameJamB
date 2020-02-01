using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : BaseModule
{
    public override void apply(GameObject player)
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        }
    }
}

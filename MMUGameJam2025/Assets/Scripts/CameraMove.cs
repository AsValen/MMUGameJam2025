using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;            // Reference to your game object
    public Vector3 offset = new Vector3(0, 0, -10); // Adjust camera offset as needed

    private float previousPlayerZ;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform not assigned!");
            enabled = false;
            return;
        }
        previousPlayerZ = player.position.z;
    }

    void LateUpdate()
    {
        // Calculate how much player moved forward on Z since last frame
        float deltaZ = player.position.z - previousPlayerZ;

        // Move camera forward by the same deltaZ amount
        transform.position += new Vector3(0, 0, deltaZ);

        // Also follow player's X and Y positions + offset
        //Vector3 targetPos = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        //transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);

        // Update previous Z for next frame
        previousPlayerZ = player.position.z;
    }
}

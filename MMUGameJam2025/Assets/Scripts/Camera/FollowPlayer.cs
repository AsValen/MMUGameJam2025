using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // awake event is executed when the object is created or enabled, for Initialize variables, setup references
    // start event is executed when the object is created or enabled and all objects are initialize, run once no matter renable or disable, Start behaviors, run logic after all setup
    // fixedUpdate event is for physics calculations, because it executes every 0.02 seconds
    // update event is game logic functions, called many times than fixedUpdate
    // lateUpdate event is for camera movement and UI for keeping track objects that have moved

    //Should follow the speed of player for camera to catch up
    public float smoothSpeed = 5f;
    public Vector3 offset;           // e.g. (0, 0, -10) to stay behind the player

    [SerializeField] private Transform target;          // Drag your player here
    [SerializeField] private GameObject followCamera;

    void LateUpdate()
    {
        if (target == null) return;

        float fixedSmoothSpeed = Time.deltaTime * smoothSpeed;

        // Only follow Z axis; keep X and Y locked
        Vector3 desiredPosition = new Vector3(
            followCamera.transform.position.x,    // Keep current X
            followCamera.transform.position.y,    // Keep current Y
            target.position.z + offset.z          // Follow player on Z + offset
        );

        Vector3 smoothedPosition = Vector3.Lerp(
            followCamera.transform.position,
            desiredPosition,
            fixedSmoothSpeed
        );

        followCamera.transform.position = smoothedPosition;
    }
}

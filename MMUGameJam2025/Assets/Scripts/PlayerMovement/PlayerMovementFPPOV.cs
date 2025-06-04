using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OOP Inheritance
//Its monobehavior as didnt inherit functions or varaibles from another class
public class PlayerMovementFPPOV : MonoBehaviour
{
    public float forwardSpeed = 15f; //constant speed at z-axis


    // maybe use fixedUpdate
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    //private void Move(Vector2 direction)
    //{
    //    // Check if the direction is small enough to ignore
    //    // this is a common optimization to avoid unnecessary calculations
    //    // Need testing??
    //    //if (direction.sqrMagnitude < 0.01)
    //    //    return;

    //    // movement is scaled properly and is smooth and consistent across different frame rates
    //    // so if framerates are low, the movement will be slower, thats why use delta time
    //    var scaledMoveSpeed = moveSpeed * Time.deltaTime;

    //    // For simplicity's sake, we just keep movement in a single plane here. Rotate
    //    // direction according to world Y rotation of player.

    //    //Quaternion is a struct that represents a rotation in 3D space
    //    //Euler angles are a way to represent 3D rotations using three angles (pitch, yaw, roll)
    //    //Quaternion creates rotation from euler angles
    //    //Unity uses quaternions for rotation because they avoid gimbal lock and handle smooth interpolation better than Euler angles.
    //    // var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);

    //    // Vector2 is a struct that represents a point in 2D space
    //    var move = new Vector2(direction.x, direction.y);
    //    // smooth, incremental movement / apply movement relative to facing direction.
    //    transform.Translate(move * scaledMoveSpeed);

    //    //transform.position is for teleporting objects
    //}
}

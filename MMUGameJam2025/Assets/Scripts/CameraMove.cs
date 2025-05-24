using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;  // assign your game object in inspector

    void LateUpdate()
    {
        if (target != null)
        {
            // Keep camera's X and Y fixed, follow target's Z only
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        }
    }
}

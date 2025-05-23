using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPM : MonoBehaviour
{
    public Transform target; // Assign your player or flying object here

    void Update()
    {
        // Follow all axes
        transform.position = target.position;
    }
}

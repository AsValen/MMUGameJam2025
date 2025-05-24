using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform cam;
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = cam.position.z;
        transform.position = pos;
    }
}

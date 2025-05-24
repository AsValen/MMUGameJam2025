using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPMZ : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = player.position.z;
        transform.position = pos;
    }
}

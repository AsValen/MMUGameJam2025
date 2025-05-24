using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstZMove : MonoBehaviour
{
    public float zSpeed = 5f;

    void Update()
    {
        transform.position += new Vector3(0, 0, zSpeed * Time.deltaTime);
    }
}

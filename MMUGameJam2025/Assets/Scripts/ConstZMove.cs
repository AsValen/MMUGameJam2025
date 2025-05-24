using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstZMove : MonoBehaviour
{
    public float zSpeed = 5f;           // Starting speed
    public float speedIncrease = 1f;    // How much to increase
    public float interval = 5f;         // Every how many seconds to increase

    private int lastInterval = 0;       // To track last whole interval passed
    private float timer = 0f;           // Keeps track of time

    void Update()
    {
        // Move the object forward in Z
        transform.position += new Vector3(0, 0, zSpeed * Time.deltaTime);

        // Update timer
        timer += Time.deltaTime;

        // Check if we've passed a new 5-second multiple
        int currentInterval = Mathf.FloorToInt(timer / interval);
        if (currentInterval > lastInterval)
        {
            zSpeed += speedIncrease;
            lastInterval = currentInterval; // Update lastInterval
        }
    }
}

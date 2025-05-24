using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFollowPlayer : MonoBehaviour
{
    public float smoothSpeed = 5f;
    public Vector3 offset;           // e.g. (0, 0, -10) to stay behind the player

    [SerializeField] private Transform target;          // Drag your player here
    [SerializeField] private GameObject background;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        float fixedSmoothSpeed = Time.deltaTime * smoothSpeed;

        // lerp is a function that interpolates (finding a value between 2 known values) between two vectors
        // it takes 3 parameters: the start position, the end position, and the interpolation factor (smoothSpeed)
        Vector3 smoothedPosition = Vector3.Lerp(background.transform.position, desiredPosition, fixedSmoothSpeed);
        background.transform.position = smoothedPosition;
    }
}

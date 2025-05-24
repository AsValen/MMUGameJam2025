using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float moveSpeed = 50f;
    private Vector2 targetPositionXY;
    private bool isMoving = false;

    void Update()
    {
        // Detect left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if ray hits something with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Set target X and Y; keep current Z
                targetPositionXY = new Vector2(hit.point.x, hit.point.y);
                isMoving = true;
            }
        }

        // Move towards the clicked X and Y target
        if (isMoving)
        {
            Vector3 currentZ = new Vector3(0, 0, transform.position.z);
            Vector3 targetPosition = new Vector3(targetPositionXY.x, targetPositionXY.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPositionXY) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}

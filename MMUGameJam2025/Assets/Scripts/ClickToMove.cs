using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float moveSpeed = 50f;
    private Vector2 targetPositionXY;
    private bool isMoving = false;

    public GameObject idle;
    public GameObject upperLeft;
    public GameObject upperRight;
    public GameObject lowerLeft;
    public GameObject lowerRight;

    [SerializeField] private Animator animator;
    void Update()
    {
        // Detect left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;

            //  Determine screen quadrant
            if (screenPos.x < Screen.width / 2f)
            {
                if (screenPos.y > Screen.height / 2f)
                {
                    animator.SetTrigger("UpperLeft");
                    upperLeft.SetActive(true);

                    idle.SetActive(false);
                    upperRight.SetActive(false);
                    lowerLeft.SetActive(false);
                    lowerRight.SetActive(false);
                    //animator.SetBool("isMoving", true); // Enable moving animation
                }
                else
                {
                    animator.SetTrigger("LowerLeft");
                    lowerLeft.SetActive(true);

                    idle.SetActive(false);
                    upperRight.SetActive(false);
                    upperLeft.SetActive(false);
                    lowerRight.SetActive(false);
                    //animator.SetBool("isMoving", true); // Enable moving animation
                }
            }
            else
            {
                if (screenPos.y > Screen.height / 2f)
                {
                    animator.SetTrigger("UpperRight");
                    upperRight.SetActive(true);

                    idle.SetActive(false);
                    upperLeft.SetActive(false);
                    lowerLeft.SetActive(false);
                    lowerRight.SetActive(false);
                    //animator.SetBool("isMoving", true); // Enable moving animation
                }
                else
                {
                    animator.SetTrigger("LowerRight");
                    lowerRight.SetActive(true);

                    idle.SetActive(false);
                    upperLeft.SetActive(false);
                    upperRight.SetActive(false);
                    lowerLeft.SetActive(false);
                    //animator.SetBool("isMoving", true); // Enable moving animation
                }
            }

            //  Raycast to detect click location in world space
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPositionXY = new Vector2(hit.point.x, hit.point.y);
                isMoving = true;
            }

            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if ray hits something with a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Set target X and Y; keep current Z
                targetPositionXY = new Vector2(hit.point.x, hit.point.y);
                isMoving = true;
            } */
        }

        // Move towards the clicked X and Y target
        if (isMoving)
        {
            Vector3 targetPosition = new Vector3(targetPositionXY.x, targetPositionXY.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPositionXY) < 0.01f)
            {
                isMoving = false;
                animator.SetBool("isMoving", false); // Disable moving animation
                idle.SetActive(true);

                upperLeft.SetActive(false);
                upperRight.SetActive(false);
                lowerLeft.SetActive(false);
                lowerRight.SetActive(false);
            }

            /*Vector3 currentZ = new Vector3(0, 0, transform.position.z);
            Vector3 targetPosition = new Vector3(targetPositionXY.x, targetPositionXY.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPositionXY) < 0.01f)
            {
                isMoving = false;
            }*/
        }
    }
}

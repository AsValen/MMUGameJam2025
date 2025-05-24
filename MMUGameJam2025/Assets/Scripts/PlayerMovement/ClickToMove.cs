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

    public AudioSource ppIdleAudio;
    public AudioSource ppUpAudio;
    public AudioSource ppDownAudio;

    [SerializeField] private Animator animator;

    void Start()
    {
        ppIdleAudio.Play();

        ppUpAudio.Stop();
        ppDownAudio.Stop();
    }
    void Update()
    {
        // Detect left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;

            Ray rayClickBoard = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayClickBoard, out RaycastHit hitClickBoard))
            {
                if (hitClickBoard.collider.CompareTag("clickBoard"))
                {
                    //Debug.Log("1");

                    //  Determine screen quadrant
                    if (screenPos.x < Screen.width / 2f)
                    {
                        //Debug.Log("2");
                        if (screenPos.y > Screen.height / 2f)
                        {
                            //Debug.Log("3");
                            animator.SetTrigger("UpperLeft");
                            upperLeft.SetActive(true);

                            idle.SetActive(false);
                            upperRight.SetActive(false);
                            lowerLeft.SetActive(false);
                            lowerRight.SetActive(false);

                            ppUpAudio.Play();
                            ppIdleAudio.Stop();
                            ppDownAudio.Stop();
                            //animator.SetBool("isMoving", true); // Enable moving animation
                        }
                        else
                        {
                            //Debug.Log("4");
                            animator.SetTrigger("LowerLeft");
                            lowerLeft.SetActive(true);

                            idle.SetActive(false);
                            upperRight.SetActive(false);
                            upperLeft.SetActive(false);
                            lowerRight.SetActive(false);

                            ppDownAudio.Play();

                            ppUpAudio.Stop();
                            ppIdleAudio.Stop();
                            //animator.SetBool("isMoving", true); // Enable moving animation
                        }
                    }
                    else
                    {
                        if (screenPos.y > Screen.height / 2f)
                        {
                            //Debug.Log("5");
                            animator.SetTrigger("UpperRight");
                            upperRight.SetActive(true);

                            idle.SetActive(false);
                            upperLeft.SetActive(false);
                            lowerLeft.SetActive(false);
                            lowerRight.SetActive(false);

                            ppUpAudio.Play();

                            ppIdleAudio.Stop();
                            ppDownAudio.Stop();
                            //animator.SetBool("isMoving", true); // Enable moving animation
                        }
                        else
                        {
                            //Debug.Log("6");
                            animator.SetTrigger("LowerRight");
                            lowerRight.SetActive(true);

                            idle.SetActive(false);
                            upperLeft.SetActive(false);
                            upperRight.SetActive(false);
                            lowerLeft.SetActive(false);

                            ppDownAudio.Play();

                            ppUpAudio.Stop();
                            ppIdleAudio.Stop();
                            //animator.SetBool("isMoving", true); // Enable moving animation
                        }
                    }
                    //Debug.Log("7");
                    //  Raycast to detect click location in world space
                    Ray ray = Camera.main.ScreenPointToRay(screenPos);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        targetPositionXY = new Vector2(hit.point.x, hit.point.y);
                        isMoving = true;
                    }

                    //Debug.Log("8");

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
            }
            
        }

        // Move towards the clicked X and Y target
        if (isMoving)
        {
            //Debug.Log("9");
            Vector3 targetPosition = new Vector3(targetPositionXY.x, targetPositionXY.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            /*Debug.Log(transform.position);
            Debug.Log(targetPositionXY);
            Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPositionXY)); */


            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), targetPositionXY) < 0.01f)
            {

                //Debug.Log("10");
                isMoving = false;
                animator.SetBool("isMoving", false); // Disable moving animation
                idle.SetActive(true);

                upperLeft.SetActive(false);
                upperRight.SetActive(false);
                lowerLeft.SetActive(false);
                lowerRight.SetActive(false);

                ppIdleAudio.Play();

                ppUpAudio.Stop();
                ppDownAudio.Stop();
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

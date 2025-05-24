using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnv : MonoBehaviour
{
    [SerializeField] private GameObject seaEnv;
    [SerializeField] private GameObject forestEnv;
    [SerializeField] private GameObject skyEnv;

    public GameObject currentEnv;
    private bool reachedDestination = false;

    public ZDistanceCount zDistanceCount;
    public float currentkiloDistance;
    public float TotalkiloDistance;
    public float lastDistanceCovered = 0f;
    public float goalDistance = 15f;

    private float timeToChangeEnv = 2f;


    void Awake()
    {
        if (currentEnv == null)
        {
            randomChooseEnv();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (currentEnv == null)
        {
            randomChooseEnv();
            return; // Make sure the rest doesn't run until an environment is chosen
        }

        TotalkiloDistance = zDistanceCount.distanceTravelled;
        currentkiloDistance = TotalkiloDistance - lastDistanceCovered;


        //Debug.Log("Current Distance: " + currentkiloDistance);
        //Debug.Log("goal: " + goalDistance);

        if (currentkiloDistance >= goalDistance)
        {
            //Debug.Log("1");
            lastDistanceCovered = TotalkiloDistance;
            currentkiloDistance = 0f;
            StartCoroutine(prepareNextEnv());
        }
    }

    IEnumerator prepareNextEnv()
    {
        //Debug.Log("2");
        // FLASH BANG OF WHITENESS, put here
        yield return new WaitForSeconds(timeToChangeEnv); // Wait for 2 seconds before spawning the next environment
        randomChooseEnv();
    }

    void randomChooseEnv()
    {
        Debug.Log("Choosing a new environment...");
        int randomEnv = Random.Range(0, 2);
        Destroy(currentEnv);

        switch (randomEnv)
        {
            case 0:
                currentEnv = Instantiate(seaEnv, transform.position, Quaternion.identity);
                break;
            //case 1:
            //    currentEnv = Instantiate(forestEnv, transform.position, Quaternion.identity);
            //    break;
            case 1:
                currentEnv = Instantiate(skyEnv, transform.position, Quaternion.identity);
                break;
        }
    }

}

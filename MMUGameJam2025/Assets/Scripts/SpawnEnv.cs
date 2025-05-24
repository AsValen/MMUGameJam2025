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

    public float currentkiloDistance;
    public float TotalkiloDistance;
    public float goalDistance = 5000f;

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
        //if(currentEnv == null)
        //{
        //    randomChooseEnv();
        //} 
        //else if (currentkiloDistance >= goalDistance)
        //{
        //    currentkiloDistance = 0f;
        //    StartCouroutine(prepareNextEnv());
        //}
    }

    IEnumerator prepareNextEnv()
    {
        // FLASH BANG OF WHITENESS, put here
        yield return new WaitForSeconds(timeToChangeEnv); // Wait for 2 seconds before spawning the next environment
        randomChooseEnv();
    }

    void randomChooseEnv()
    {
        int randomEnv = Random.Range(0, 3);
        switch (randomEnv)
        {
            case 0:
                currentEnv = Instantiate(seaEnv, transform.position, Quaternion.identity);
                break;
            case 1:
                currentEnv = Instantiate(forestEnv, transform.position, Quaternion.identity);
                break;
            case 2:
                currentEnv = Instantiate(skyEnv, transform.position, Quaternion.identity);
                break;
        }
    }

}

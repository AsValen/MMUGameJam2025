using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthPoints = 20f;
    [SerializeField] private PlaneHealth planeHealth;

    [SerializeField] private GameState state;

    void Start()
    {
        healthPoints = 20f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        planeHealth = playerObj.GetComponent<PlaneHealth>();
        state = playerObj.GetComponent<GameState>();
    }

    void Update()
    {
        if(state.isHealthBoost)
        {
            //Refactor damage, should be check if maxhealth is greater than 100 after adding then only proceed to add
            state.isHealthBoost = false;
            planeHealth.currentHealth += healthPoints;
            //Debug.Log(planeHealth.currentHealth);
            if (planeHealth.currentHealth > planeHealth.maxHealth)
            {
                planeHealth.currentHealth = planeHealth.maxHealth;
            }

            Destroy(gameObject);
        }
    }

}

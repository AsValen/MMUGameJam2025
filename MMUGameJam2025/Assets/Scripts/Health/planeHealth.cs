using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour
{
    // starting with 5 electric symbols
    public float currentHealth = 50f;

    // 10 electric symbols
    public float maxHealth = 100f;


    public float damageInterval = 1f;
    public int damagePerTick = 1;

    private float nextDamageTime = 1f;

    [SerializeField] private InvulnerableBoost invulnerableBoost;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50f;
        maxHealth = 100f;
    }

    void Update()
    {

        if (invulnerableBoost != null && invulnerableBoost.maintainedInvulnerable)
        {
            return; // Don't apply damage
        }

        //Time.time, time since the start of the game
        //Time.deltaTime, time since last frame

        //Debug.Log(Time.time);
        //Debug.Log(nextDamageTime);
        while (Time.time >= nextDamageTime)
        {
            nextDamageTime = Time.time + damageInterval;
            currentHealth -= damagePerTick;
            if (currentHealth <= 0)
            {
                currentHealth = 0;

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "invulnerableBoost")
        {
            invulnerableBoost = collision.gameObject.GetComponent<InvulnerableBoost>();
        }
    }

    void takeDamage()
    {
        //Refactor damage, should be check if maxhealth is greater than 0 after deducting then only proceed to deduct
        nextDamageTime += damageInterval;
        currentHealth -= damagePerTick;
        if (currentHealth <= 0)
        {
            currentHealth = 0;

        }
    }
}

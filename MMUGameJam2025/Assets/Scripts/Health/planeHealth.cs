using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour
{
    // starting with 5 electric symbols
    public float currentHealth = 50f;

    [SerializeField] private HealthPickup healthPickup;

    // 10 electric symbols
    private float maxHealth = 100f;


    public float damageInterval = 1f;
    public int damagePerTick = 5;

    private float nextDamageTime = 0f;

    [SerializeField] private InvulnerableBoost invulnerableBoost;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50f;
        maxHealth = 100f;
    }

    void Update()
    {
        while (Time.deltaTime >= nextDamageTime && !invulnerableBoost.maintainedInvulnerable)
        {
            //Refactor damage, should be check if maxhealth is greater than 0 after deducting then only proceed to deduct
            nextDamageTime += damageInterval;
            maxHealth -= damagePerTick;
            if (maxHealth <= 0)
            {
                maxHealth = 0;
                
            }
        }
        damageTimer = Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlaneHealth planeHealth;
    private float healthUI;

    public Image healthBar;
    public float healthAmt = 100f;

    void Update()
    {
        healthUI = planeHealth.currentHealth;

        if(healthAmt <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        /*if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            addFuel(5);
        }*/
    }

    public void TakeDamage(float damage)
    {
        healthAmt -= damage;
        healthBar.fillAmount = healthAmt / 100f;
    }
    public void addFuel(float fuelAmt)
    {
        healthAmt += fuelAmt;
        healthAmt = Mathf.Clamp(healthAmt, 0, 100);

        healthBar.fillAmount = healthAmt / 100f;
    }
}

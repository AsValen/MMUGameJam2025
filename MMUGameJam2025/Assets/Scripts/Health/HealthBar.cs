using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlaneHealth planeHealth;
    [SerializeField] private Image healthBar;

    void Update()
    {
        if (planeHealth != null && healthBar != null)
        {
            float current = planeHealth.currentHealth;
            float max = planeHealth.maxHealth;

            healthBar.fillAmount = current / max;

            if (current <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

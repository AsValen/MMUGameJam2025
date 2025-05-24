using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlaneHealth planeHealth; // Reference to the PlaneHealth script
    [SerializeField] private Image healthBar;         // The UI Image with "Filled" type

    public AudioSource gameplayAudio;

    void Start()
    {
        // If not assigned in Inspector, find the Player by tag and get PlaneHealth component
        if (planeHealth == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                planeHealth = player.GetComponent<PlaneHealth>();
            }
        }

        // Optional: Warn if healthBar is missing
        if (healthBar == null)
        {
            Debug.LogWarning("HealthBar UI Image not assigned!");
        }

        gameplayAudio.Play();
    }

    void Update()
    {
        if (planeHealth != null && healthBar != null)
        {
            float current = planeHealth.currentHealth;
            float max = planeHealth.maxHealth;

            // Update the health bar fill amount
            healthBar.fillAmount = current / max;

            // Optional: Check for "death"
            if (current <= 0)
            {
                gameplayAudio.Stop();
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
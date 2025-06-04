using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewHealthCode : MonoBehaviour
{
    //[Header("Health Settings")]
    public float currentHealth = 50f;
    public float maxHealth = 100f;
    public float damageInterval = 1f;
    public int damagePerTick = 1;

    //[Header("UI Settings")]
    public Image healthBar;

    [Header("Invulnerability")]
    //[SerializeField] private InvulnerableBoost invulnerableBoost;

    private float nextDamageTime = 1f;

    void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    void Update()
    {
        //if (invulnerableBoost != null && invulnerableBoost.maintainedInvulnerable)
        //{
        //    return;
        //}

        // Continuous damage over time
        while (Time.time >= nextDamageTime)
        {
            nextDamageTime = Time.time + damageInterval;
            TakeDamage(damagePerTick);
        }

        // Reload scene if health is zero
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void AddFuel(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("invulnerableBoost"))
    //    {
    //        invulnerableBoost = collision.gameObject.GetComponent<InvulnerableBoost>();
    //    }
    //}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    [SerializeField] protected float damageAmount; // Amount of damage to apply
    [SerializeField] protected PlaneHealth planeHealth;

    // Start is called before the first frame update
    void Start()
    {
        planeHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlaneHealth>();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // Stop movement immediately
            // applying this on player's rb
            //rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;

            planeHealth.currentHealth -= damageAmount;

            Destroy(gameObject);
        }
    }
}

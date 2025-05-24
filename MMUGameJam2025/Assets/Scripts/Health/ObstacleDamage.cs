using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    [SerializeField] protected float damageAmount; // Amount of damage to apply
    [SerializeField] protected PlaneHealth planeHealth;
    [SerializeField] protected GameObject player; // Reference to the player transform

    [SerializeField] private float maxZDistance = 250f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        planeHealth = player.GetComponent<PlaneHealth>();
    }

    void Update()
    {
        if (player.transform.position.z - transform.position.z > maxZDistance)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collide");
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {

            //Debug.Log("touch");
            //Debug.Log("Player Health: " + planeHealth.currentHealth);

            planeHealth.currentHealth -= damageAmount;

            Destroy(gameObject);
        } 
    }
}

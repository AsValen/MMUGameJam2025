using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool isSpeedBoost = false;
    public bool isInvulnerable = false;
    public bool isHealthBoost = false;

    public bool isDebugMode = false;

    //[SerializeField] private GameObject speedBoost;
    //[SerializeField] private GameObject invulnerableBoost;

    // Both objects colide need to have rigidbody and collider
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "speedBoost")
        {
            isSpeedBoost = true;
            if(isDebugMode) Debug.Log("speedBoost");
        }
        else if (collision.gameObject.tag == "invulnerableBoost")
        {
            isInvulnerable = true;
            if (isDebugMode) Debug.Log("invulnerableBoost");
        }
        else if (collision.gameObject.tag == "healthPickup")
        {
            isHealthBoost = true;
            if (isDebugMode) Debug.Log("healthPickup");
        }

        // Maybe put this if there is bubble pop effect after getting the abilities
        //Instantiate(explosionPrefab, position, rotation);
    }
}

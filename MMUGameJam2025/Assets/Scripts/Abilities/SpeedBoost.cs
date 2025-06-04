using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    [SerializeField] private float maxZDistance = 250f;
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        if (player.transform.position.z - transform.position.z > maxZDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

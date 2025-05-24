using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedBoost = 2f;
    [SerializeField] private float durationAbilities = 5f;

    [SerializeField] private ConstZMove constZMove;
    [SerializeField] private GameState state;

    [SerializeField] private float maxZDistance = 250f;
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        constZMove = player.GetComponent<ConstZMove>();
        state = player.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateSpeed());

        if (player.transform.position.z - transform.position.z > maxZDistance)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ActivateSpeed()
    {
        if (state.isSpeedBoost)
        {
            state.isSpeedBoost = false;
            constZMove.zSpeed *= speedBoost;
            // Might be a bug here, maybe need to turn off physics when hitting, so that the powerup wont fly weird
            yield return new WaitForSeconds(durationAbilities);
            Debug.Log("destroy");
            constZMove.zSpeed /= speedBoost;

            Destroy(gameObject);
        }
    }
}

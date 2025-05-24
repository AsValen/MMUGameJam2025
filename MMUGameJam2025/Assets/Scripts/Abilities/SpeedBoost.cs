using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedBoost = 2f;
    [SerializeField] private float durationAbilities = 5f;

    [SerializeField] private PlayerMovementFPPOV playerMovement;
    [SerializeField] private GameState state;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerMovement = playerObj.GetComponent<PlayerMovementFPPOV>();
        state = playerObj.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateSpeed());
    }

    IEnumerator ActivateSpeed()
    {
        if (state.isSpeedBoost)
        {
            state.isSpeedBoost = false;
            playerMovement.forwardSpeed *= speedBoost;
            // Might be a bug here, maybe need to turn off physics when hitting, so that the powerup wont fly weird
            yield return new WaitForSeconds(durationAbilities);
            playerMovement.forwardSpeed /= speedBoost;

            Destroy(gameObject);
        }
    }
}

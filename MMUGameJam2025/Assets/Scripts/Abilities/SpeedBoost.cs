using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedBoost = 2f;
    [SerializeField] private float durationAbilities = 5f;

    [SerializeField] private paperMovement playerMovement;
    [SerializeField] private GameState state;

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
            playerMovement.speed = playerMovement.speed * speedBoost;
            yield return new WaitForSeconds(durationAbilities);
            playerMovement.speed = playerMovement.speed / speedBoost;
        }
    }
}

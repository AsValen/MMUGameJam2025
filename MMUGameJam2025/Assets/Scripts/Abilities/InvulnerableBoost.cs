using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableBoost : MonoBehaviour
{
    public bool maintainedInvulnerable = false;
    [SerializeField] private float durationAbilities = 5f;

    [SerializeField] private GameState state;

    void Start()
    {
        state = GameObject.FindGameObjectWithTag("Player").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateInvulnerable());
    }

    IEnumerator ActivateInvulnerable()
    {
        if (state.isInvulnerable)
        {
            state.isInvulnerable = false;
            maintainedInvulnerable = true;
            yield return new WaitForSeconds(durationAbilities);
            maintainedInvulnerable = false;

            Destroy(gameObject);
        }
    }
}

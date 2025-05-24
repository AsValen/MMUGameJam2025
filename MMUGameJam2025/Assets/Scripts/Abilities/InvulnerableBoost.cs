using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnerableBoost : MonoBehaviour
{
    public bool maintainedInvulnerable = false;
    [SerializeField] private float durationAbilities = 5f;

    [SerializeField] private GameState state;

    [SerializeField] private float maxZDistance = 250f;
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        state = GameObject.FindGameObjectWithTag("Player").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateInvulnerable());

        if (player.transform.position.z - transform.position.z > maxZDistance)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ActivateInvulnerable()
    {
        if (state.isInvulnerable)
        {
            state.isInvulnerable = false;
            maintainedInvulnerable = true;
            yield return new WaitForSeconds(durationAbilities);
            Debug.Log("destroy");
            maintainedInvulnerable = false;

            Destroy(gameObject);
        }
    }
}

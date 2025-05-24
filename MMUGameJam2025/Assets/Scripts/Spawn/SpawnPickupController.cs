using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickupController : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private GameObject invulnerableItem;
    [SerializeField] private GameObject speedItem;
    [SerializeField] private GameObject healthItem;

    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private bool waitForNextSpawn = false;

    [SerializeField] private Vector3 spawnPosition;

    private Renderer planeRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        planeRenderer = spawnPoint.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        if (waitForNextSpawn) return;

        Bounds bounds = planeRenderer.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        // Example: spawn to the right of the plane
        spawnPosition = new Vector3(
            randomX,  // Just 1 unit to the right of the plane
            randomY,
            spawnPoint.transform.position.z
        );

        int randomPickup = Random.Range(0, 3);

        switch (randomPickup)
        {
            case 0:
                Instantiate(invulnerableItem, spawnPosition, invulnerableItem.transform.rotation);
                break;
            case 1:
                Instantiate(speedItem, spawnPosition, speedItem.transform.rotation);
                break;
            case 2:
                Instantiate(healthItem, spawnPosition, healthItem.transform.rotation);
                break;
        }

        StartCoroutine(waitNextObstacleSpawn());
    }

    IEnumerator waitNextObstacleSpawn()
    {
        waitForNextSpawn = true;
        yield return new WaitForSeconds(spawnInterval);
        waitForNextSpawn = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private GameObject seaObstacle;
    [SerializeField] private GameObject forestObstacle;
    [SerializeField] private GameObject skyObstacle;

    [SerializeField] private SpawnEnv spawnEnv;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private bool waitForNextSpawn = false;

    [SerializeField] private Vector3 spawnPosition;

    [SerializeField] private Renderer planeRenderer;

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
        if(waitForNextSpawn) return;

        Bounds bounds = planeRenderer.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        // Example: spawn to the right of the plane
        spawnPosition = new Vector3(
            randomX,  // Just 1 unit to the right of the plane
            randomY,
            spawnPoint.transform.position.z
        );

        switch (spawnEnv.currentEnv.name)
        { 
            case "sea env":
                Instantiate(seaObstacle, spawnPosition, Quaternion.identity);
                break;
            case "forest env":
                Instantiate(forestObstacle, spawnPosition, Quaternion.identity);
                break;
            case "sky env":
                Instantiate(skyObstacle, spawnPosition, Quaternion.identity);
                break;
            default:
                Debug.LogWarning("Unknown environment type: " + spawnEnv.currentEnv.name);
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

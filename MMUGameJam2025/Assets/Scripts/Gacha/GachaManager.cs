using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    //Assign your gacha item prefabs here into a list
    public List<GameObject> gachaPrefabs;

    public int pullCount = 3;
    public float pullDelay = 1f;

    //Spawns selected item at a respective position
    public Transform spawnPoint;

    public bool debugMode = false;

    private GameObject selectedPrefab;
    private GameObject currentSpawn;
    private List<GameObject> gachaResults = new List<GameObject>();

    private void PullOneSequence(bool saveResults)
    {
        // Remove previous pull if it exists
        if (currentSpawn != null)
        {
            Destroy(currentSpawn);
        }

        // Pick a random prefab
        int index = Random.Range(0, gachaPrefabs.Count - 1);
        selectedPrefab = gachaPrefabs[index];

        // Instantiate it at the spawn point
        // Quaternion.identity is the default rotation (no rotation), object is aligned with world or parent object
        currentSpawn = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);

        if(saveResults) gachaResults.Add(selectedPrefab);

        checkGachaResults(debugMode);
    }

    // Coroutine for delay between pulls
    private IEnumerator PullMultipleSequence(int count, float delay, bool saveResults)
    {
        for (int i = 0; i < count; i++)
        {
            PullOneSequence(saveResults);
            yield return new WaitForSeconds(delay); // wait before next pull
        }
    }

    // Multiple Rolls
    public void PullMultiple()
    {
        StartCoroutine(PullMultipleSequence(pullCount, pullDelay, true));
    }

    public void PullOne()
    {
        PullOneSequence(true);
    }

    public void PullOneWithMultipleAnimation()
    {
        StartCoroutine(PullMultipleSequence(pullCount, pullDelay, false));
        gachaResults.Add(selectedPrefab);
        checkGachaResults(debugMode);
    }

    private void checkGachaResults(bool debug)
    {
        if (!debug) return;

        // Check if the gacha results are empty
        if (gachaResults.Count == 0)
        {
            Debug.Log("No gacha results to display.");
            return;
        }

        int count = 0;

        // Display the gacha results
        foreach (GameObject result in gachaResults)
        {
            Debug.Log("Gacha Result:" + count + result.name);
            count++;
        }
    }
}

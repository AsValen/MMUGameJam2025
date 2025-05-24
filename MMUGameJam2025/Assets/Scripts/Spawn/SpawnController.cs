using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject clickSpace;

    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = clickSpace.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
       // Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
    }
}

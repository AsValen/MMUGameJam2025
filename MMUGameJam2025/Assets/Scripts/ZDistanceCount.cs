using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZDistanceCount : MonoBehaviour
{
    public Transform player; // Drag your player object here
    public TextMeshProUGUI counterText; // Drag your UI text here

    private float startZ; // We'll store the starting Z position

    void Start()
    {
        // Save the Z position at the start of the game
        startZ = player.position.z;
    }

    void Update()
    {
        // Get current Z position
        float currentZ = player.position.z;

        // Calculate distance in km (100 units = 1 km)
        float distanceTravelled = (currentZ - startZ) / 100f;

        // Round to 1 decimal place
        counterText.text = distanceTravelled.ToString("F1") + " ";
    }
}

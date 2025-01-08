using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Coin Spawn Variables
    [SerializeField] private CoinsGenerator coinsGenerator;
    [SerializeField] private int amount;
    [SerializeField] private Vector3 rangeMin = new Vector3(-10, 0, -10);
    [SerializeField] private Vector3 rangeMax = new Vector3(10, 0, 10);
    [SerializeField] private float objectRadius = 1f;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        int spawnedCount = 0;

        while (spawnedCount < amount)
        {
            // Generate a random position within the range
            Vector3 randomPosition = new Vector3(
                Random.Range(rangeMin.x, rangeMax.x),
                rangeMax.y,
                Random.Range(rangeMin.z, rangeMax.z)
            );

            // Check if this position overlaps with any already spawned
            if (IsPositionValid(randomPosition))
            {
                Instantiate(coinsGenerator.GenerateCoin(), randomPosition, Quaternion.identity);
                spawnedPositions.Add(randomPosition);
                spawnedCount++;
            }
        }

        if (spawnedCount < amount)
        {
            Debug.LogWarning($"Could only spawn {spawnedCount}/{amount} objects without overlap.");
        }
    }

    private bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < objectRadius * 2)
            {
                return false; // Too close to an existing object
            }
        }

        return true; // Valid position
    }
}

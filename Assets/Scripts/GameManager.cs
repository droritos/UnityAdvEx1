using System.Collections.Generic;
using UnityEngine;
using static Character;

public class GameManager : MonoBehaviour
{
    //Coin Spawn Variables
    [Header("References")]
    [SerializeField] UIManager uiManager;
    [SerializeField] Character elfCharacter;
    [SerializeField] CoinsGenerator coinsGenerator;

    [Header("Game Manager Data")]
    [SerializeField] private int amount;
    [SerializeField] private Vector3 rangeMin = new Vector3(-25, 1.5f, -25);
    [SerializeField] private Vector3 rangeMax = new Vector3(25, 1.5f, 25);
    [SerializeField] private float objectRadius = 1f;


    private List<Vector3> _spawnedPositions = new List<Vector3>();

    private void Start()
    {
        uiManager.DecreaseSpeed += HandleAgentSpeed;
        elfCharacter.OnCoinCollected += AmountChecker;
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
                _spawnedPositions.Add(randomPosition);
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
        foreach (Vector3 spawnedPosition in _spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < objectRadius * 2)
            {
                return false; // Too close to an existing object
            }
        }

        return true; // Valid position
    }

    private void AmountChecker(InformationSend sent)
    {
        // Check when you collect all coins
        if (amount == sent.CollectedAmount)
        {
            uiManager.SetCollectedText(true);
        }
    }

    private void HandleAgentSpeed(float newSpeed, AgentMovement agentMovement)
    {
        if (newSpeed != 1)
        {
            // When in a surfaces
            agentMovement.Agent.speed *= newSpeed;
        }
        else
        {
            // when you out of any surfaces
            agentMovement.ResetSpeed();
        }
    }
}

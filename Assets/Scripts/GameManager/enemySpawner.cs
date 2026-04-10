/****************************************************************************
* File Name: enemySpawner.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script spawns enemies at random spawn points after a certain delay and also checks the game state to stop spawning when the player dies.
*
****************************************************************************/
using System.Collections;
using UnityEngine;


public class enemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning Settings")]
    [Tooltip("List of enemies this spawner can spawn")]
        [SerializeField] private GameObject[] enemyPrefab;
    [Tooltip("List of positions the enemies can spawn at")]
        [SerializeField] Transform[] spawnPoints;
    [Tooltip("Minimum delay between enemy spawns")]
        [SerializeField] private float spawnDelayMin = 5f;
    [Tooltip("Maximum delay between enemy spawns")]
        [SerializeField] private float spawnDelayMax = 6;
    [Tooltip("The amount of enemies to spawn each time.")]
        [SerializeField] private int spawnAmount = 3;
    [Tooltip("The amount of seconds to decrease the spawn delay by each round.")]
        [SerializeField] private float roundSpawnDelay = 0.25f;

    private float nextSpawnTime;

    // Update is called once per frame
    /// <summary>
    /// Handles enemy spawning each frame based on the current game state and round.
    /// </summary>
    private void Update()
    {
        // Current round
        int round = gameObject.GetComponent<roundManager>().getRound();

        // Check if the game is paused
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            // Check when to spawn enemy
            if (Time.time > nextSpawnTime)
            {
                spawnEnemy();
                //spawn delay
                nextSpawnTime = Time.time + Random.Range(spawnDelayMin, (spawnDelayMax - (float)(round * roundSpawnDelay) - (float)(round * roundSpawnDelay)));
            }
        }
    }

    /// <summary>
    /// Called to spawn in an enemy at a given spawnpoint
    /// </summary>
    private void spawnEnemy()
    {
        //randomizes the spawn point for the enemy to spawn at and then spawns the enemy at that location and randomizes which enemy spawns.

        for(int i = 0; i < spawnAmount; i++)
        {
            // Gets a spawnpoint
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            // Gets an enemy to spawn
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            // Where around the spawnpoint they spawn
            float randSpawnDis = Random.Range(2f, 4f);

            // Spawns enemy
            Instantiate(enemyPrefab[randomEnemy], spawnPoints[randomSpawn].position + new Vector3(randSpawnDis, -1, 0), spawnPoints[randomSpawn].rotation);
        }
        
    }
}



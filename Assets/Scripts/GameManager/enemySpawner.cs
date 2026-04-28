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

    [System.Serializable] struct enemySpawn
    {
        [Tooltip("Minimum delay between enemy spawns")]
            [SerializeField] public float spawnDelayMin;// = 5f;
        [Tooltip("Maximum delay between enemy spawns")]
            [SerializeField] public float spawnDelayMax; // = 6;
        [Tooltip("The amount of enemies to spawn each time.")]
            [SerializeField] public int spawnAmount; // = 3;
        [Tooltip("The amount of seconds to decrease the spawn delay by each round.")]
            [SerializeField] public float roundSpawnDelay; // = 0.25f;
        [Tooltip("The time until the next enemy spawn")]
            [SerializeField] public float spawnDelayTime; // = 0.1f;
    }
    [Header("Enemy Round Settings")]
    [SerializeField] private enemySpawn[] enemyRoundSettings;


    //Extra enemies to spawn per round
        private int spawnAmountPerRound;
        private int round;

    private void Start()
    {
        spawnAmountPerRound = gameObject.GetComponent<roundManager>().getRound();
    }
    private float nextSpawnTime;

    // Update is called once per frame
    /// <summary>
    /// Handles enemy spawning each frame based on the current game state and round.
    /// </summary>
    private void Update()
    {
        
        if (!gameObject.GetComponent<roundManager>().getStartDelay())
        {
            // Current round
            round = gameObject.GetComponent<roundManager>().getRound();

            // Check if the game is paused
            if (!gameObject.GetComponent<gameManager>().getGameState())
            {
                // Check when to spawn enemy
                if (Time.time > nextSpawnTime)
                {
                    spawnEnemy();
                    //spawn delay
                    nextSpawnTime = Time.time + Random.Range(enemyRoundSettings[round].spawnDelayMin, (enemyRoundSettings[round].spawnDelayMax - (float)(round * enemyRoundSettings[round].roundSpawnDelay)));
                }
            }
        }
    }

    /// <summary>
    /// Called to spawn in an enemy at a given spawnpoint
    /// </summary>
    private void spawnEnemy()
    {
        //randomizes the spawn point for the enemy to spawn at and then spawns the enemy at that location and randomizes which enemy spawns.

        StartCoroutine(spawnEnemyDelay());
        
    }

    IEnumerator spawnEnemyDelay()
    {
        int lastPos = -1;
        int randomSpawn = -1;
        for (int i = 0; i < enemyRoundSettings[round].spawnAmount + spawnAmountPerRound; i++)
        {
            // Waits for the spawn delay and then spawns an enemy
            yield return new WaitForSeconds(enemyRoundSettings[round].spawnDelayTime);
            // Gets an enemy to spawn
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            // Where around the spawnpoint they spawn
            float randSpawnDisX = Random.Range(2f, 4f);
            // Randomizes the direction they spawn in Y axis
            float randSpawnDisY = Random.Range(-1f, 1f);
            // Rerandomizes spawnpoint until not equal to last spawnpoint
            while (lastPos == randomSpawn)
            {
            // Gets a spawnpoint
            randomSpawn = Random.Range(0, spawnPoints.Length);
            }
            // Spawns enemy
            Instantiate(enemyPrefab[randomEnemy], spawnPoints[randomSpawn].position + new Vector3(randSpawnDisX, randSpawnDisY, 0), spawnPoints[randomSpawn].rotation);
            lastPos = randomSpawn;
        }
    }
}



/****************************************************************************
* File Name: enemySpawner.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script spawns enemies at random spawn points after a certain delay and also checks the game state to stop spawning when the player dies.
*
****************************************************************************/
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class enemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning Settings")]
    [SerializeField] protected GameObject[] enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [Tooltip("The delay between each enemy spawn in seconds.")]
    [SerializeField] protected float spawnDelayMin = 5f;
    [SerializeField] protected float spawnDelayMax = 6;
    protected float nextSpawnTime;

    [Tooltip("The amount of enemies to spawn each time.")]
    [SerializeField] protected int spawnAmount = 3;

    private void Update()
    {
        int round = gameObject.GetComponent<roundManager>().getRound();

        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            if (Time.time > nextSpawnTime)
            {
                spawnEnemy();
                //spawn delay
                nextSpawnTime = Time.time + Random.Range(spawnDelayMin, (spawnDelayMax - (float)(round * 0.25f)));
            }
        }
    }

    public void spawnEnemy()
    {
        //randomizes the spawn point for the enemy to spawn at and then spawns the enemy at that location and randomizes which enemy spawns.
        
        for (int i = 0; i< spawnAmount; i++)
        {
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawnDis = Random.Range(1, 2);
            Instantiate(enemyPrefab[randomEnemy], spawnPoints[randomSpawn].position + new Vector3(randSpawnDis, 0, 0), spawnPoints[randomSpawn].rotation);
        }
            
    }
}


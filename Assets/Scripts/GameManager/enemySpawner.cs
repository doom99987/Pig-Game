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
    [SerializeField] protected GameObject[] enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [Tooltip("The delay between each enemy spawn in seconds.")]
    [SerializeField] protected float spawnDelayMin = 5f;
    [SerializeField] protected float spawnDelayMax = 6;
    protected float nextSpawnTime;

    [Tooltip("The amount of enemies to spawn each time.")]
    [SerializeField] protected int spawnAmount = 3;

    [Tooltip("The amount of seconds to decrease the spawn delay by each round.")]
    [SerializeField] protected float roundSpawnDelay = 0.25f;


    // Update is called once per frame
    /// <summary>
    /// Handles enemy spawning each frame based on the current game state and round.
    /// </summary>
    private void Update()
    {
        int round = gameObject.GetComponent<roundManager>().getRound();

        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            if (Time.time > nextSpawnTime)
            {
                spawnEnemy();
                //spawn delay
                nextSpawnTime = Time.time + Random.Range(spawnDelayMin, (spawnDelayMax - (float)(round * roundSpawnDelay)));
            }
        }
    }

    public void spawnEnemy()
    {
        //randomizes the spawn point for the enemy to spawn at and then spawns the enemy at that location and randomizes which enemy spawns.
        
        int[] spawnSave = new int[spawnPoints.Length];
        for (int j = 0; j < spawnSave.Length; j++)
        {
            spawnSave[j] = -1;
        }
        for (int i = 0; i< spawnAmount; i++)
        {
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            foreach (int num in spawnSave)
            {
                if (num == randomSpawn)
                {
                    randomSpawn = Random.Range(0, spawnPoints.Length);
                }
            for(int j = 0; j < spawnSave.Length; j++)
            {
                if(spawnSave[j] == 0)
                {
                    spawnSave[j] = randomSpawn;
                    break;
                }
            }
            }
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawnDis = Random.Range(2, 4);
            Instantiate(enemyPrefab[randomEnemy], spawnPoints[randomSpawn].position + new Vector3(randSpawnDis, 0, 0), spawnPoints[randomSpawn].rotation);
            //stall so the enemies don't all spawn at the same time and on top of one another
            StartCoroutine(wait(1f));
        }
    }

    /// <summary>
    ///  coroutine that waits for a specified amount of time before allowing the next enemy to spawn.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}


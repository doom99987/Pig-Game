using UnityEngine;
using UnityEngine.Rendering;

public class enemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning Settings")]
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] protected float spawnDelay = 5f;
    protected float nextSpawnTime = 5;

    private void Update()
    {
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            if (Time.time > nextSpawnTime)
            {
                spawnEnemy();
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
    }

    public void spawnEnemy()
    {
        int random = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[random].position, spawnPoints[random].rotation);
    }
}


using UnityEngine;
using UnityEngine.Rendering;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    protected float spawnDelay = 5f;

    private void Update()
    {
        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay < 0)
            {
                spawnEnemy();
                spawnDelay = 5f;
            }
        }
    }

    public void spawnEnemy()
    {
        int random = Random.Range(1, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[random].position, Quaternion.identity);
    }
}


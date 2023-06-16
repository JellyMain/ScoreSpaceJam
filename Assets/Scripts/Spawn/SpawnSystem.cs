using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private float coldownSpawnEnemy;
    [SerializeField] private int enemyCount = 10;
    private int count = 0;

    private Coroutine createEnemiesCoroutine;

    private IEnumerator CreateEnemies()
    {
        yield return new WaitForSeconds(coldownSpawnEnemy);
        if (count < enemyCount)
        {
            count++;
            Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity);
        }
        else
        {
            StopCoroutine(createEnemiesCoroutine);
            createEnemiesCoroutine = null;
        }
    }

    void Start()
    {
        createEnemiesCoroutine = StartCoroutine(CreateEnemies());
    }

    private void OnDestroy()
    {
        StopCoroutine(createEnemiesCoroutine);
        createEnemiesCoroutine = null;
    }
}

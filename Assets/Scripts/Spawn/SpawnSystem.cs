using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private float coldownSpawnEnemy;
    [SerializeField] private float coldownWaveSpawnEnemy;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private int waveCount = 5;
    private int countCurrentEnemy = 0;

    private List<Enemy> createdEnemies = new List<Enemy>();

    private Coroutine createEnemiesCoroutine;
    private Coroutine createWaveEnemiesCoroutine;

    private int countWave = 0;
    private IEnumerator StartWaveCreateEnemies()
    {
        while (countCurrentEnemy < enemyCount)
        {
            if (countCurrentEnemy < enemyCount)
            {
                countCurrentEnemy++;
                var enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity);
                createdEnemies.Add(enemy);
            }
            else
            {
                if (createEnemiesCoroutine != null)
                {
                    StopCoroutine(createEnemiesCoroutine);
                    createEnemiesCoroutine = null;
                }
            }

            yield return new WaitForSeconds(coldownSpawnEnemy);
        }

        enemyCount += 5;
    }
    private void DeleteEnemyFromList(Enemy enemy)
    {
        createdEnemies.Remove(enemy);

        if (createdEnemies.Count == 0)
        {
            createWaveEnemiesCoroutine = StartCoroutine(WaveManager());
        }
    }

    private IEnumerator WaveManager()
    {
        if (countWave < 5)
        {
            countWave++;
            StopCoroutine(createEnemiesCoroutine);
            createEnemiesCoroutine = null;

            yield return new WaitForSeconds(coldownWaveSpawnEnemy);
            createEnemiesCoroutine = StartCoroutine(StartWaveCreateEnemies());
        }
    }

    void Start()
    {
        createEnemiesCoroutine = StartCoroutine(StartWaveCreateEnemies());
        EventAgregator.WaveEnemyManager.AddListener(DeleteEnemyFromList);
    }

    private void OnDestroy()
    {
        StopCoroutine(createEnemiesCoroutine);
        createEnemiesCoroutine = null;

        StopCoroutine(createWaveEnemiesCoroutine);
        createWaveEnemiesCoroutine = null;
    }
}

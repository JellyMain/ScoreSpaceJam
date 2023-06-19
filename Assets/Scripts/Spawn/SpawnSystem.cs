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

    public List<Enemy> createdEnemies = new List<Enemy>();

    private Coroutine createEnemiesCoroutine;
    private Coroutine createWaveEnemiesCoroutine;

    private int countWave = 0;

    private PlayerUI _playerUI;
    public static SpawnSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


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

        enemyCount += 1;
    }
    private void DeleteEnemyFromList(Enemy enemy)
    {
        createdEnemies.Remove(enemy);
        countCurrentEnemy--;
        if (countCurrentEnemy == 0 || createdEnemies.Count == 0)
        {
            createWaveEnemiesCoroutine = StartCoroutine(WaveManager());
        }
    }

    private IEnumerator WaveManager()
    {
        Debug.Log(countWave);
        if (countWave < 1)
        {
            _playerUI.timerForWavef += 30f;
            countWave++;
            StopCoroutine(createEnemiesCoroutine);
            createEnemiesCoroutine = null;

            yield return new WaitForSeconds(coldownWaveSpawnEnemy);
            createEnemiesCoroutine = StartCoroutine(StartWaveCreateEnemies());
        }
        else
        {
            EventAgregator.PlayerWin.Invoke();
        }
    }

    void Start()
    {
        _playerUI = FindObjectOfType<PlayerUI>();
        createEnemiesCoroutine = StartCoroutine(StartWaveCreateEnemies());
        EventAgregator.WaveEnemyManager.AddListener(DeleteEnemyFromList);
    }

    private void OnDestroy()
    {
        if (createEnemiesCoroutine != null)
        {
            StopCoroutine(createEnemiesCoroutine);
            createEnemiesCoroutine = null;
        }

        if (createWaveEnemiesCoroutine != null)
        {
            StopCoroutine(createWaveEnemiesCoroutine);
            createWaveEnemiesCoroutine = null;
        }
    }
}

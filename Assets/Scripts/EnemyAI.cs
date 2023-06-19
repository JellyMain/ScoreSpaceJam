using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float maxDistance = 0;
    [SerializeField] private float minDistance = 0;
    [SerializeField] private float obstacleAvoidDistance = 0;
    [SerializeField] private float moveSpeed = 2f;

    private bool shouldAvoid = false;

    private float sineWave = 0;


    private void Start()
    {
        StartCoroutine(RandomAvoidanceChecks());
    }


    private void LateUpdate()
    {
        MaintainDistance();
        AvoidObstacles();
    }


    private void Update()
    {
        sineWave += Time.deltaTime;
    }

    protected void MaintainDistance()
    {
        if (Player.Instance == null) return;
        Vector2 distanceVector = Player.Instance.transform.position - transform.position;

        if (distanceVector.magnitude > maxDistance || distanceVector.magnitude < minDistance)
        {
            // Normalized direction towards the player
            Vector2 direction = distanceVector.normalized;

            // Add a lateral offset based on a sine wave
            float lateralOffsetMagnitude = Mathf.Sin(sineWave);
            Vector2 lateralOffset = new Vector2(-direction.y, direction.x) * lateralOffsetMagnitude;

            // Apply the lateral offset to the direction
            direction += lateralOffset;

            // Move the enemy
            float speedMultiplier = distanceVector.magnitude > maxDistance ? 1f : -1f;
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)direction, speedMultiplier * moveSpeed * Time.deltaTime);
        }
    }

    private Transform GetClosestEnemy()
    {
        Enemy closestEnemy = SpawnSystem.Instance.createdEnemies
            .Where(enemy => enemy != null && enemy.gameObject != gameObject)
            .OrderBy(enemy => (enemy.transform.position - transform.position).sqrMagnitude)
            .FirstOrDefault();

        if (closestEnemy == null)
        {
            return null;
        }

        return closestEnemy.transform;
    }

    private IEnumerator RandomAvoidanceChecks()
    {
        while (true)
        {
            // Random delay between checks
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            shouldAvoid = true;
        }
    }

    private void AvoidObstacles()
    {
        if (!shouldAvoid) return;

        Vector2 separation = Vector2.zero;
        int nearbyEnemiesCount = 0;

        foreach (Enemy enemy in SpawnSystem.Instance.createdEnemies)
        {
            if (enemy != null && enemy != this)
            {
                Vector2 difference = transform.position - enemy.transform.position;
                float distance = difference.magnitude;

                if (distance < obstacleAvoidDistance && distance > 0.0001f)
                {
                    difference = difference.normalized / distance;
                    separation += difference;
                    nearbyEnemiesCount++;
                }
            }
        }

        if (nearbyEnemiesCount > 0)
        {
            separation /= nearbyEnemiesCount;

            // Add a random offset to the direction
            Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            separation += randomOffset;

            // Check if the separation vector is valid before moving the enemy
            if (!float.IsNaN(separation.x) && !float.IsNaN(separation.y))
            {
                float speedMultiplier = 2f;
                transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)separation, moveSpeed * speedMultiplier * Time.deltaTime);
            }
        }

        shouldAvoid = false;
    }
}


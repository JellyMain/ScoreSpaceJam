using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    PlayerBullet,
    EnemyBullet
}

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D bulletRb;
    public float damage;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject bulletEffect;

    public BulletType bulletType;

    private Vector2 originalDirection;
    private float timeAlive;
    private bool isWaveMove = false;
    private float waveAmplitude;
    private float waveFrequency;



    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    public Bullet SpawnBullet(Vector2 pointStartMove)
    {
        Bullet spawnedBullet = Instantiate(bulletPrefab, pointStartMove, Quaternion.identity).GetComponent<Bullet>();
        return spawnedBullet;
    }




    public void SetBulletDirection(Vector2 direction)
    {
        bulletRb.velocity = direction * bulletSpeed;
        originalDirection = direction * bulletSpeed;
        timeAlive = 0f;
    }

    public void MoveInWavePattern(float amplitude, float frequency)
    {
        isWaveMove = true;
        waveAmplitude = amplitude;
        waveFrequency = frequency;
    }

    private void FixedUpdate()
    {
        if (isWaveMove)
        {
            timeAlive += Time.fixedDeltaTime;
            Vector2 perpendicular = new Vector2(-originalDirection.y, originalDirection.x).normalized;
            bulletRb.velocity = originalDirection + Mathf.Sin(timeAlive * waveFrequency) * waveAmplitude * perpendicular;
        }
    }

    private void DestroyBullet()
    {
        isWaveMove = false;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletType == BulletType.EnemyBullet && other.CompareTag("Player"))
        {
            if (Player.Instance.isDashing) return;
            Health health = other.GetComponent<Health>();
            health.ReduceHealth(damage);
            Destroy(gameObject);
        }
        else if (bulletType == BulletType.PlayerBullet && other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();
            health.ReduceHealth(damage);
            Destroy(gameObject);
        }
    }
}

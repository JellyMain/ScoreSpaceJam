using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D bulletRb;
    public int damage;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject bulletEffect;
    public Action OnDestroy;


    private void OnEnable()
    {
        OnDestroy += DestroyBullet;
    }

    private void OnDisable()
    {
        OnDestroy -= DestroyBullet;
    }

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
    }

    private void DestroyBullet()
    {
        SoundManager.Instance.PlayDestroyBullet(this.transform.position);
        Instantiate(bulletEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

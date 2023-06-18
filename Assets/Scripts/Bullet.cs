using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D bulletRb;
    public int damage;
    public float bulletSpeed;
    public GameObject bulletPrefab;


    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    public Bullet SpawnBullet()
    {
        Bullet spawnedBullet = Instantiate(bulletPrefab, Player.Instance.transform.position, Quaternion.identity).GetComponent<Bullet>();
        return spawnedBullet;
    }

    public void SetBulletDirection(Vector2 direction)
    {
        bulletRb.velocity = direction * bulletSpeed;
    }
}

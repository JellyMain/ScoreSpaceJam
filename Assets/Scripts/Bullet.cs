using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D bulletRb;
    public int damage;
    public GameObject bulletPrefab;


    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    public Bullet SpawnBullet(Vector2 pointSpawnBullet)
    {
        Bullet spawnedBullet = Instantiate(bulletPrefab, pointSpawnBullet, Quaternion.identity).GetComponent<Bullet>();
        return spawnedBullet;
    }

    public void SetBulletDirection(Vector2 direction)
    {
        bulletRb.velocity = direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Instance.UpdatePlayerHP(damage);
        } 
    }
}

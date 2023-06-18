using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IShoot
{
    public void Shoot(Vector2 direction, Bullet currentBullets, Vector2 pointSpawnBullet)
    {

        Bullet spawnedBullet = currentBullets.SpawnBullet(pointSpawnBullet);
        spawnedBullet.SetBulletDirection(direction);
    }
}

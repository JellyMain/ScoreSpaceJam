using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IShoot
{
    public void Shoot(Vector2 direction, Bullet currentBullets)
    {

        Bullet spawnedBullet = currentBullets.SpawnBullet();
        spawnedBullet.SetBulletDirection(direction);
    }
}

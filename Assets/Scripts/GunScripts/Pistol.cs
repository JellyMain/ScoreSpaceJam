using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PistolPattern", menuName = "ShootingPatterns/PistolPattern")]
public class Pistol : IShoot
{
    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats)
    {
        Bullet spawnedBullet = currentBullets.SpawnBullet();
        spawnedBullet.SetBulletDirection(direction);
    }
}

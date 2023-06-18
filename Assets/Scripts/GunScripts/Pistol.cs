using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PistolPattern", menuName = "ShootingPatterns/PistolPattern")]
public class Pistol : IShoot
{
    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats, Vector2 startPointBulletMove)
    {
        Bullet spawnedBullet = currentBullets.SpawnBullet(startPointBulletMove);
        spawnedBullet.SetBulletDirection(direction);
    }
}

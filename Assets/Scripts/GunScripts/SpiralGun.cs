using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiralGunPattern", menuName = "ShootingPatterns/SpiralGunPattern")]
public class SpiralGun : IShoot
{
    public float spreadAngle;
    private float angle = 0;

    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats, Vector2 startPointBulletMove)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Vector2 bulletDirection = rotation * direction;

        Bullet spawnedBullet = currentBullets.SpawnBullet(startPointBulletMove);
        spawnedBullet.SetBulletDirection(bulletDirection);
        spawnedBullet.transform.position = startPointBulletMove;

        angle += spreadAngle;
    }
}

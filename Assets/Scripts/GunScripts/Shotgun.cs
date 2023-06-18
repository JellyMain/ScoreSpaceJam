using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunPattern", menuName = "ShootingPatterns/ShotgunPattern")]
public class Shotgun : IShoot
{
    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats, Vector2 startPointBulletMove)
    {
        for (int i = 0; i < gunStats.bulletsPerShot; i++)
        {
            Bullet spawnedBullet = currentBullets.SpawnBullet(startPointBulletMove);
            Vector2 spread = new Vector2();

            float currentAngle = (gunStats.spreadAngle / (gunStats.bulletsPerShot - 1)) * i;
            float spreadRadians = currentAngle * Mathf.Deg2Rad;
            spread.x = direction.x * Mathf.Cos(spreadRadians) - direction.y * Mathf.Sin(spreadRadians);
            spread.y = direction.x * Mathf.Sin(spreadRadians) + direction.y * Mathf.Cos(spreadRadians);

            spawnedBullet.SetBulletDirection(spread);
        }
    }
}

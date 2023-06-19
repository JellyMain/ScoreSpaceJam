using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveGunPattern", menuName = "ShootingPatterns/WaveGunPattern")]
public class WaveGun : IShoot
{
    public float amplitude = 1;
    public float frequency = 1;

    public override void Shoot(Vector2 direction, Bullet bulletPrefab, Gun gunStats, Vector2 startPointBulletMove)
    {
        // Instantiate and set up the bullet
        Bullet spawnedBullet = bulletPrefab.SpawnBullet(startPointBulletMove);
        spawnedBullet.SetBulletDirection(direction);

        // Make the bullet move in a wave pattern
        spawnedBullet.MoveInWavePattern(amplitude, frequency);
    }
}
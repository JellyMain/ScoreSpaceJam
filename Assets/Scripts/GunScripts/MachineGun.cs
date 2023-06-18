using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGunPattern", menuName = "ShootingPatterns/MachineGunPattern")]
public class MachineGun : IShoot
{
    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats)
    {
        Bullet spawnedBullet = currentBullets.SpawnBullet();

        float maxSpread = gunStats.gunAccuracy * 45f;
        float spread = Random.Range(-maxSpread, maxSpread);

        Quaternion spreadRotation = Quaternion.Euler(0, 0, spread);

        Vector2 spreadDirection = spreadRotation * direction;

        spawnedBullet.SetBulletDirection(spreadDirection);
    }
}

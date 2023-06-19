using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGunPattern", menuName = "ShootingPatterns/MachineGunPattern")]
public class MachineGun : IShoot
{
    [Range(0, 1)] public float gunAccuracy;

    public override void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats, Vector2 startPointBulletMove)
    {
        Bullet spawnedBullet = currentBullets.SpawnBullet(startPointBulletMove);

        float maxSpread = gunAccuracy * 45f;
        float spread = Random.Range(-maxSpread, maxSpread);

        Quaternion spreadRotation = Quaternion.Euler(0, 0, spread);

        Vector2 spreadDirection = spreadRotation * direction;

        spawnedBullet.SetBulletDirection(spreadDirection);
    }
}

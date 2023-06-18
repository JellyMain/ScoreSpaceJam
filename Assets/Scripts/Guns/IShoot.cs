using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot
{
    public void Shoot(Vector2 direction, Bullet currentBullets, Vector2 pointSpawnBullet);
}

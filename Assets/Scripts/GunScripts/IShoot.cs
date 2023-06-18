using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IShoot : ScriptableObject
{
    public abstract void Shoot(Vector2 direction, Bullet currentBullets, Gun gunStats, Vector2 startPointBulletMove);
}

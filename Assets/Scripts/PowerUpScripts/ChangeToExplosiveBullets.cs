using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeToExplosiveBulletsPowerUp", menuName = "PowerUps/ChangeToExplosiveBulletsPowerUp")]
public class ChangeToExplosiveBullets : PowerUps
{
    public Bullet explosiveBullets;

    public override void Activate()
    {
        PlayerShooting.Instance.SetNewBullets(explosiveBullets);
    }
}

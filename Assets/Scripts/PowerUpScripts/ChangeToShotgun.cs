using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeToShotgunPowerUp", menuName = "PowerUps/ChangeToShotgunPowerUp")]
public class ChangeToShotgun : PowerUps
{
    public Gun shotgun;

    public override void Activate()
    {
        PlayerShooting.Instance.SetNewGun(shotgun);
    }
}

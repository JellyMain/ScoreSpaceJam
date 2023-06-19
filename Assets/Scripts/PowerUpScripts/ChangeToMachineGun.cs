using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeMachineGunPowerUp", menuName = "PowerUps/ChangeToMachineGunPowerUp")]
public class ChangeToMachineGun : PowerUps
{
    public Gun machineGun;

    public override void Activate()
    {
        PlayerShooting.Instance.SetNewGun(machineGun);
    }
}

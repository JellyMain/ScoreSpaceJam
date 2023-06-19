using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseDamagePowerUp", menuName = "PowerUps/IncreaseDamagePowerUp")]
public class IncreaseDamage : PowerUps
{
    public float percentage;

    public override void Activate()
    {
        PlayerShooting.Instance.IncreaseDamage(percentage);
    }
}
